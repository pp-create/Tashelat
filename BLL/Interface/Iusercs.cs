using DAL;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface Iusers
    {
        int Add(UserVM model); Guid? login(UserVM model);
        bool Edit(UserVM model);
        IEnumerable<UserVM> GetAll();
        UserVM GetById(Guid id);
        int count();
        bool Delete(Guid id);
    }
}
