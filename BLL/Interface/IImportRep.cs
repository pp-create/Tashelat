using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IImportRep
    {
        int Add(ImportViewModel model);
        bool Edit(ImportViewModel model);
        IEnumerable<ImportViewModel> GetAll();
        ImportViewModel GetById(Guid id);
        int count();
        bool Delete(Guid id);
    }
}
