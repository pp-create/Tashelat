using AutoMapper;
using BLL.Helper;
using BLL.Interface;
using DAL.Database;
using DAL.Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ViewModel;

namespace BLL.Servies
{
    public class UserRep:Iusers
    {
        public UserRep(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            Mapper = mapper;
        }


        public ApplicationDbContext db { get; }
        public IMapper Mapper { get; }

        public int Add(UserVM model)
        {
            try
            {
                
                if (model==null)
                {
                    var data1 = Mapper.Map<Users>(model);
                    data1.password = "1234";    data1.UserName = "zaid";
                    var uer = db.User.FirstOrDefault(x => x.password == data1.password && x.UserName == data1.UserName);
                    if (uer==null)
                    {
                        db.User.Add(data1);

                        db.SaveChanges();
                        return 1;
                    }
                  
                    return 1;

                }
                var uesr = db.User.FirstOrDefault(x => x.password == model.password && x.UserName == model.UserName);
                if (uesr!=null)
                {
                    return 1;
                }
                var data = Mapper.Map<Users>(model);
                if (model.funtion!=null)
                {
                    foreach (var item in model.funtion)
                    {
                        FuntionUsre obj = new FuntionUsre();
                        obj.userid = data.Id;
                        obj.namefuntion = item;
                        db.FuntionUsre.Add(obj);
                    }
              

                }
                db.User.Add(data);
             
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
                var data = db.User.Find(id);
                db.User.Remove(data);
                db.SaveChanges(); return true;
            }
            catch (Exception)
            {

                return true;
            }
        }



        public bool Edit(UserVM model)
        {
            try
            {

                var data = Mapper.Map<Import>(model);
                if (model.funtion != null)
                {
                    foreach (var item in model.funtion)
                    {
                        var obj = db.FuntionUsre.Find(data.Id);

                       
                        obj.userid = data.Id;
                        obj.namefuntion = item;
                        db.FuntionUsre.Add(obj);
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

        public IEnumerable<UserVM> GetAll()
        {

            var data = db.User.ToList();
            var model = Mapper.Map<List<UserVM>>(data);


       
            return (model.ToList());

        }

        public UserVM GetById(Guid id)
        {
            try
            {
                var data = db.User.Find(id);

                var model = Mapper.Map<UserVM>(data);
             
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

      

        public Guid? login(UserVM model)
        {
            // Validate input
            if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.password))
            {
                return null; // or throw an appropriate exception
            }

            // Assuming `User` table has `UserName` and `HashedPassword` fields
            var user = db.User.FirstOrDefault(x => x.UserName == model.UserName && x.password == model.password);

            // Check if user exists and password is correct
            if (user != null)
            {
                return user.Id;
            }

            // Return null if login fails
            return null;
        }

        // Method to verify password (example)
        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            // Implement password verification logic (e.g., hash the enteredPassword and compare with storedHash)
            // This is a placeholder; replace with actual implementation
            return enteredPassword == storedHash;
        }

    }
}
