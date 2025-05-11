using DAL.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface Icontect
    {
        int Add(ContactVM model);
        bool Edit(ContactVM model);
        IEnumerable<ContactVM> GetAll();
        ContactVM GetById(Guid id);
        int count();
        bool Delete(Guid id);
    }
}
