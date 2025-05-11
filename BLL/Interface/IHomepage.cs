using DAL;
using DAL.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IHomepage
    {
        int Add(HomepageViewModel model, List<Data> files);
        bool Edit(filebbookViewModel model);
        IEnumerable<filebbookViewModel> GetAll();
        HomepageViewModel GetById(Guid id);
        public IEnumerable<filebbookViewModel> GetAllbook(Guid id); public IEnumerable<filebbookViewModel> GetAlbook();
        int count();
        bool Delete(Guid id);
    }
}
