using AutoMapper;
using BLL.Helper;
using BLL.Interface;
using DAL.Database;
using DAL.Entities;
using DAL.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servies
{
    public class RequestRepo : IRequest
    {
        public RequestRepo(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            Mapper = mapper;
        }


        public ApplicationDbContext db { get; }
        public IMapper Mapper { get; }

        public int Addmassage(MassagerUesrsVM model)
        {
            try
            {

                var data = Mapper.Map<MassagerUesrs>(model);
                data.Id = Guid.NewGuid();
                db.MassagerUesrs.Add(data);
              

                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public int Addrequest(RequestVM model)
        {
            try
            {
               
                var data = Mapper.Map<Request>(model);
                var id =  db.Requestes.OrderByDescending(r => r.Id).Select(r => r.Id).FirstOrDefault();
                
                if (id==0)
                {
                    id = 1;
                }
                else
                {
                    id++;
                }
                data.idcustomer = "60"+ id;
                data.Status = "انتظار";
                db.Requestes.Add(data);
               

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

        public bool Deletemassage(Guid id)
        {
            try
            {
                var data = db.MassagerUesrs.Find(id);
                db.MassagerUesrs.Remove(data);
                db.SaveChanges(); return true;
            }
            catch (Exception)
            {

                return true;
            }
        }

        public bool Deleterequet(int id)
        {
            try
            {
                var data = db.Requestes.Find(id);
                db.Requestes.Remove(data);
                db.SaveChanges(); return true;
            }
            catch (Exception)
            {

                return true;
            }
        }

        public bool Edit(RequestVM model)
        {
            try
            {
                var ir = db.Requestes.Find(model.Id);


                // Detach the existing tracked entity
                db.Entry(ir).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

                // Create a new entity and map the data
                var data = Mapper.Map<Request>(model);
                data.idcustomer = ir.idcustomer;
                data.namebank = "ww"; data.salary ="000";
                data.nid = "333";
                // Attach and mark as modified
                db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                // Save changes
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<MassagerUesrsVM> GetAll()
        {
            var data = db.MassagerUesrs.ToList();
            var model = Mapper.Map<List<MassagerUesrsVM>>(data);
            return (model.ToList());
        }

        public IEnumerable<RequestVM> GetAllrequet()
        {
            var data = db.Requestes.Where(x => x.IsDeleted == false).ToList();
            var model = Mapper.Map<List<RequestVM>>(data);
            return (model.ToList());
        }  public RequestVM screachrequet(string id)
        {
            var data = db.Requestes.FirstOrDefault(x => x.idcustomer == id);
            var model = Mapper.Map<RequestVM>(data);
            return (model);
        }

        public RequestVM GetById(int id)
        {
            try
            {
                var data = db.Requestes.Find(id);

                var model = Mapper.Map<RequestVM>(data);
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<RequestVM> GetAllrequet(string UserId)
        {
            var data = db.Requestes.Where(x => x.IsDeleted == false&&x.userId.ToString()== UserId).ToList();
            var model = Mapper.Map<List<RequestVM>>(data);
            return (model.ToList());
        }
    }
}
