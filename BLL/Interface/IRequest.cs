using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IRequest
    {
        public RequestVM  screachrequet(string id);
        int Addmassage(MassagerUesrsVM model);
        int Addrequest(RequestVM model);
        bool Edit(RequestVM model);
        IEnumerable<MassagerUesrsVM> GetAll();   IEnumerable<RequestVM> GetAllrequet();IEnumerable<RequestVM> GetAllrequet(string UserId);
        RequestVM GetById(int id);
        int count();
        bool Deletemassage(Guid id);    bool Deleterequet(int id);
    }
}
