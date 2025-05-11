using AutoMapper;
using BLL.Helper;
using BLL.Interface;
using DAL.Database;
using DAL.Entities;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servies
{
    public class ReadingRep : IReadingRep
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public ReadingRep(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public int Add(ReadingVM model)
        {
            try
            {
                var data=mapper.Map<Reading>(model);
                if (model.files != null)
                {
                   
                       
                        data.Image = UploodImage.SaveFile(model.files, "ReadingImage");
                     

                }
                db.Readings.Add(data);

                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public bool Delete(Guid id,Guid senderId)
        {
            var data=db.Readings.Where(m=>m.FK_SenderId==senderId&&m.Id==id).FirstOrDefault();
            if (data !=null)
            {
                db.Readings.Remove(data);
                return true;
            }
            return false;
        }

        public IEnumerable<ReadingVM> GetAll()
        {
            throw new NotImplementedException();
        }

        public ReadingVM GetById(Guid id)
        {
           

            var data3 =db.Readings.Where(m=>m.Id==id).FirstOrDefault();
            var masage=mapper.Map<ReadingVM>(data3);
            return masage;
        }

        public List<ReadingVM> GetByIdAll(Guid id, int weake)
        {
            if (weake == null || weake == 0)
            {
                weake = 1;
            }
            var data = DateTime.Now.AddDays((-7 * weake) - 1);

            var data3 = db.Readings.Where(m => m.CreationDate >= data && (m.FK_SenderId == id || m.FK_ReseverId == id)).ToList();
            var masage = mapper.Map<List<ReadingVM>>(data3);
            return masage;
        }

        public List<ReadingVM> GetByIdResever(Guid id, int weake)
        {
            if (weake == null || weake == 0)
            {
                weake = 1;
            }
            var data = DateTime.Now.AddDays((-7 * weake) - 1);

            var data3 = db.Readings.Where(m => m.CreationDate >= data &&  m.FK_ReseverId == id).ToList();
            var masage = mapper.Map<List<ReadingVM>>(data3);
            foreach (var item in masage)
            {
                item.Resever = db.User.Where(x => x.Id == item.FK_ReseverId).FirstOrDefault().UserName;
                item.sender = db.User.Where(x => x.Id == item.FK_SenderId).FirstOrDefault().UserName;

            }
            return masage;
        }

        public List<ReadingVM> GetByIdSender(Guid id, int weake)
        {
            if (weake == null || weake == 0)
            {
                weake = 1;
            }
            var data = DateTime.Now.AddDays((-7 * weake) - 1);

            var data3 = db.Readings.Where(m => m.CreationDate >= data && m.FK_SenderId == id ).Distinct().ToList();
            
            
            var masage = mapper.Map<List<ReadingVM>>(data3);
            foreach (var item in masage)
            {
                item.Resever = db.User.Where(x => x.Id == item.FK_ReseverId).FirstOrDefault().UserName;
                item.sender = db.User.Where(x => x.Id == item.FK_SenderId).FirstOrDefault().UserName;

            }
            return masage;
        }

        public bool seen(Guid id)
        {
            var data=db.Readings.Where(x=>x.Id == id).FirstOrDefault();
            data.Seeen=true;
            db.SaveChanges();
            return true;
        }
    }
}
