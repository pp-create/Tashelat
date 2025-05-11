using DAL;
using DAL.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IReadingRep
    {
        int Add(ReadingVM model);
        IEnumerable<ReadingVM> GetAll();
        List <ReadingVM> GetByIdAll(Guid id, int weake);
       ReadingVM GetById(Guid id);

        List<ReadingVM> GetByIdSender(Guid id, int weake);
        List<ReadingVM> GetByIdResever(Guid id, int weake);

        bool Delete(Guid id, Guid senderId);
        bool seen(Guid id);


    }
}
