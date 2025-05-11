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
    public class sideRepo : IServucesVM
    {
      

        public sideRepo(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            Mapper = mapper;
        }


        public ApplicationDbContext db { get; }
        public IMapper Mapper { get; }

        public int Add(ServicesVM model)
        {
            try
            {
                var data = Mapper.Map<Services>(model);
               data.file= UploodImage.SaveFile(model.file1,"Image");
                db.side.Add(data);

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
                var data = db.side.Find(id);
                UploodImage.RemoveFile("Image", data.file);
                db.side.Remove(data);
                db.SaveChanges(); return true;
            }
            catch (Exception)
            {

                return true;
            }
        }



        public bool Edit(ServicesVM model)
        {
            try
            {

                var data = Mapper.Map<Services>(model);

                db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;


                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public IEnumerable<ServicesVM> GetAll()
        {

            var data = db.side.Where(x => x.IsDeleted == false).ToList();
            var model = Mapper.Map<List<ServicesVM>>(data);



            return (model.ToList());

        }



        public ServicesVM GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
