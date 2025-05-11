using AutoMapper;
using BLL.Helper;
using BLL.Interface;
using DAL.Database;
using DAL.Entities;
using DAL.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servies
{
    
    public class AboutRepo : IAbout
    {
        public AboutRepo(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            Mapper = mapper;
        }


        public ApplicationDbContext db { get; }
        public IMapper Mapper { get; }

        public int Add(AboutVM model)
        {
            try
            {

                var data = Mapper.Map<About>(model);
                data.Id = Guid.NewGuid();
                db.About.Add(data);
                data.file = UploodImage.SaveFile(model.file1, "Image");
            
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
                var data = db.About.Find(id);
                data.IsDeleted = true;
                db.SaveChanges(); return true;
            }
            catch (Exception)
            {

                return true;
            }
        }

        public bool Edit(AboutVM model)
        {
            try
            {
                // Retrieve the existing entity from the DbContext
                var existingEntity = db.About
                                       .Where(e => e.Id == model.Id)
                                       .FirstOrDefault();

                if (existingEntity == null)
                {
                    // Handle the case where the entity does not exist
                    return false;
                }

                // Remove old file if exists
                if (model.file1 != null)
                {
                    UploodImage.RemoveFile("Image", existingEntity.file);
                    existingEntity.file = UploodImage.SaveFile(model.file1, "Image");
                }

                // Map properties from model to existingEntity
                Mapper.Map(model, existingEntity);

                // Handle file updates
           

                // Save changes
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception message for debugging
             
                return false;
            }



        }

        public IEnumerable<AboutVM> GetAll()
        {

            var data = db.About.Where(x => x.IsDeleted == false).ToList();
            var model = Mapper.Map<List<AboutVM>>(data);
            return (model.ToList());

        }

        public AboutVM GetById(Guid id)
        {
            try
            {
                var data = db.About.Find(id);

                var model = Mapper.Map<AboutVM>(data);
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
