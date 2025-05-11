using AutoMapper;
using BLL.Helper;
using BLL.Interface;
using DAL.Database;
using DAL.Entities;
using DAL.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servies
{
    
    public class ContactRepo : Icontect
    {
        public ContactRepo(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            Mapper = mapper;
        }


        public ApplicationDbContext db { get; }
        public IMapper Mapper { get; }

        public int Add(ContactVM model)
        {
            try
            {

                var data = Mapper.Map<Contact>(model);
                data.Id = Guid.NewGuid();
                db.Contact.Add(data);
               
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
                var data = db.Contact.Find(id);
                data.IsDeleted = true;
                db.SaveChanges(); return true;
            }
            catch (Exception)
            {

                return true;
            }
        }

        public bool Edit(ContactVM model)
        {
            try
            {
                var data = Mapper.Map<Contact>(model);

              
               
                db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public IEnumerable<ContactVM> GetAll()
        {

            var data = db.Contact.Where(x => x.IsDeleted == false).ToList();
            var model = Mapper.Map<List<ContactVM>>(data);
            return (model.ToList());

        }

        public ContactVM GetById(Guid id)
        {
            try
            {
                var data = db.Contact.Find(id);

                var model = Mapper.Map<ContactVM>(data);
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
