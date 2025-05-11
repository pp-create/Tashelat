using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IRepliescostomercs
    {
        int Add(RepliescostomerVm model);
        bool Edit(RepliescostomerVm model);
        IEnumerable<RepliescostomerVm> GetAll();
        RepliescostomerVm GetById(Guid id);
        int count();
        bool Delete(Guid id);
    }
}
