using AutoMapper;
using BLL.Interface;
using DAL.Database;
using DAL.Entities;
using DAL;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Helper;
using Microsoft.AspNetCore.Http;
using System.Data.Common;

namespace BLL.Servies
{
    public class HomepageRepo : IHomepage
    {
        public HomepageRepo(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            Mapper = mapper;
        }


        public ApplicationDbContext db { get; }
        public IMapper Mapper { get; }

        public int Add(HomepageViewModel model, List<Data> files)
        {
            try
            {

               
              
                if (files != null)
                {
                    foreach (var item in files)
                    {
                        BookFile file = new BookFile();
                        var data1Q = db.side.FirstOrDefault(x => x.sidename == item.Title);
                        file.Answer = data1Q.contect;
                        file.Title = item.Title;
                        file.url = item.Url;
                        if (item.Files!=null)
                        {
                            file.Name = UploodImage.SaveFile(item.Files, "Image");
                        }
                       
                        file.FK_ImportBook =Guid.NewGuid();
                        db.BookFiles.Add(file);



                    }

                }
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }

        }

        public int count()
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            try
            {
                var data = db.Homepage.Find(id);
              
                var data1 = db.BookFiles.Where(x => x.Id == id).ToList();
                if (data1.Count() != 0)
                {
                    foreach (var item in data1)
                    {
                        UploodImage.RemoveFile("Image", item.Name);
                        
                        db.BookFiles.Remove(item);

                    }

                }
              
                
                db.SaveChanges(); return true;
            }
            catch (Exception)
            {

                return true;
            }
        }

        public bool Edit(filebbookViewModel model)
        {
            try
            {
                // Retrieve the existing entity from the DbContext
                var existingEntity = db.BookFiles
                                       .Where(e => e.FK_ImportBook == model.Id)
                                       .FirstOrDefault();

                if (existingEntity == null)
                {
                    // Handle the case where the entity does not exist
                    return false;
                }

                // Remove old file if new files are provided
                if (model.Files != null)
                {
                    // Ensure existingEntity.Name is not null or empty
                    if (!string.IsNullOrEmpty(existingEntity.Name))
                    {
                        UploodImage.RemoveFile("Image", existingEntity.Name);
                    }

                    // Save the new file and update the entity with the new file name
                    existingEntity.Name = UploodImage.SaveFile(model.Files, "Image");
                }

                // Retrieve the content based on the title
                var data1Q = db.side.FirstOrDefault(x => x.sidename == model.Title);
                if (data1Q != null)
                {
                    existingEntity.Answer = data1Q.contect;
                }

                existingEntity.Title = model.Title;

                // Save changes to the database
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception message for debugging
                // Consider using a logging framework instead of Console.WriteLine
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }




        }

        public IEnumerable<filebbookViewModel> GetAll()
        {

            var data = db.BookFiles.Where(x => x.IsDeleted == false).ToList();
            var model = Mapper.Map<List<filebbookViewModel>>(data);
            return (model.ToList());

        }
        public IEnumerable<filebbookViewModel> GetAllbook(Guid id)
        {

            var data = db.BookFiles.Where(x => x.FK_ImportBook==id).ToList();
            var model = Mapper.Map<List<filebbookViewModel>>(data);
            return (model.ToList());

        }  public IEnumerable<filebbookViewModel> GetAlbook()
        {

            var data = db.BookFiles.ToList();
            var model = Mapper.Map<List<filebbookViewModel>>(data);
            return (model.ToList());

        }
        public HomepageViewModel GetById(Guid id)
        {
            try
            {
                var data = db.Homepage.Find(id);

                var model = Mapper.Map<HomepageViewModel>(data);
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
