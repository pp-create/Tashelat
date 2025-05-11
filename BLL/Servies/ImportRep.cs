using AutoMapper;
using BLL.Helper;
using BLL.Interface;
using DAL;
using DAL.Database;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servies
{
    public class ImportRep : IImportRep
    {

        public ImportRep(ApplicationDbContext db, IMapper mapper) { 
            this.db = db;
            Mapper = mapper;
        }


        public ApplicationDbContext db { get; }
        public IMapper Mapper { get; }

        public int Add(ImportViewModel model)
        {
            try
            {
                var data = Mapper.Map<Import>(model);

                db.Imports.Add(data);
                if (model.Images != null)
                {
                    foreach (var item in model.Images)
                    {
                        BookFile file=new BookFile();
                        file.Name= UploodImage.SaveFile(item, "Image");
                        file.FK_ImportBook = data.Id;
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
                var data = db.Imports.Find(id);
                data.IsDeleted = true;
                db.SaveChanges(); return true;
            }
            catch (Exception)
            {

                return true;
            }
        }

      

        public bool Edit(ImportViewModel model)
        {
            try
            {
                var data1 = db.BookFiles.Where(x => x.FK_ImportBook == model.Id).ToList();
                var data = Mapper.Map<Import>(model);
                if (model.Images.Count() != 0)
                {
                   
                    if (data1.Count() !=0)
                    {
                        foreach(var item in data1)
                        {
                            UploodImage.RemoveFile("Image", item.Name);
                            db.BookFiles.Remove(item);

                        }

                    }
                    foreach (var item in model.Images)
                    {
                        BookFile file = new BookFile();
                        file.Name = UploodImage.SaveFile(item, "Image");
                        file.FK_ImportBook = data.Id;
                        db.BookFiles.Add(file);



                    }

                }
                db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public IEnumerable<ImportViewModel> GetAll()
        {
            
            var data= db.Imports.Where(x=>x.IsDeleted==false).ToList();
            var model=Mapper.Map<List<ImportViewModel>>(data);

            
            foreach (var item in model)
            {
                var ImagesName = db.BookFiles.Where(x => x.FK_ImportBook == item.Id).Select(x => x.Name).ToList();
                foreach (var item1 in ImagesName)
                {
                    item.ImageName.Add(item1);

                }


            }
            return (model.ToList());

        }

        public ImportViewModel GetById(Guid id)
        {
            try
            {
                var data = db.Imports.Find(id);

                var model = Mapper.Map<ImportViewModel>(data);
                var ImagesName = db.BookFiles.Where(x => x.FK_ImportBook == id).Select(x => x.Name).ToList();

                model.ImageName = ImagesName;
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

      
    }
}
