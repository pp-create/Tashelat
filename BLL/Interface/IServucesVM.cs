using DAL;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IServucesVM
    {
        int Add(ServicesVM model);
        bool Edit(ServicesVM model);
        IEnumerable<ServicesVM> GetAll();
        ServicesVM GetById(Guid id);
        int count();
        bool Delete(Guid id);
    }
}
