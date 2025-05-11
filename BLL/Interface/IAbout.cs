using DAL.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IAbout
    {
        int Add(AboutVM model);
        bool Edit(AboutVM model);
        IEnumerable<AboutVM> GetAll();
        AboutVM GetById(Guid id);
        int count();
        bool Delete(Guid id);
    }
}
