using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
   public interface IQuestions
    {
        int Add(QuestionsVM model);
        bool Edit(QuestionsVM model);
        IEnumerable<QuestionsVM> GetAll();
        QuestionsVM GetById(Guid id);
        IEnumerable<QuestionsVM> GetById(string sideName);

        int count();
        bool Delete(Guid id);
    }
}
