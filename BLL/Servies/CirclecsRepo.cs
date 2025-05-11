using AutoMapper;
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
    public class CirclecsRepo : IQuestions
    {

        public CirclecsRepo(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            Mapper = mapper;
        }


        public ApplicationDbContext db { get; }
        public IMapper Mapper { get; }

        public int Add(QuestionsVM model)
        {
            try
            {
               
              
                var data = Mapper.Map<Questions>(model);
      
                db.Circlecs.Add(data);

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
                var data = db.Circlecs.Find(id);
                data.IsDeleted = true;
                db.SaveChanges(); return true;
            }
            catch (Exception)
            {

                return true;
            }
        }



        public bool Edit(QuestionsVM model)
        {
            try
            {

                var data = Mapper.Map<Questions>(model);
          
                db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;


                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public IEnumerable<QuestionsVM> GetAll()
        {

            var data = db.Circlecs.Where(x => x.IsDeleted == false).ToList();
            
            var model = Mapper.Map<List<QuestionsVM>>(data);
           


            return (model.ToList());

        }
     
        

        public QuestionsVM GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QuestionsVM> GetById(string sideName)
        {
            var data = db.Circlecs.Where(x => x.IsDeleted == false&&x.contect==sideName).ToList();

            var model = Mapper.Map<List<QuestionsVM>>(data);



            return (model);
        }
    }
}
