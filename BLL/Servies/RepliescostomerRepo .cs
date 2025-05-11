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
    public class RepliescostomerRepo : IRepliescostomercs
    {
      

        public RepliescostomerRepo(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            Mapper = mapper;
        }


        public ApplicationDbContext db { get; }
        public IMapper Mapper { get; }

        public int Add(RepliescostomerVm model)
        {
            try
            {
                var data = Mapper.Map<Repliescostomer>(model);
                data.file = UploodImage.SaveFile(model.file1, "Image");
                db.Repliescostomer.Add(data);

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
                var data = db.Repliescostomer.Find(id);
                UploodImage.RemoveFile(data.file, "Image");
                data.IsDeleted = true;
                db.SaveChanges(); return true;
            }
            catch (Exception)
            {

                return true;
            }
        }



        public bool Edit(RepliescostomerVm model)
        {
            try
            {

                var data = Mapper.Map<Repliescostomer>(model);
                var data1 = db.Repliescostomer.Find(model.Id).file;
                UploodImage.RemoveFile(data1, "Image");
                data.file = UploodImage.SaveFile(model.file1, "Image");
                db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;


                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public IEnumerable<RepliescostomerVm> GetAll()
        {

            var data = db.Repliescostomer.Where(x => x.IsDeleted == false).ToList();
            var model = Mapper.Map<List<RepliescostomerVm>>(data);



            return (model.ToList());

        }



        public RepliescostomerVm GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
