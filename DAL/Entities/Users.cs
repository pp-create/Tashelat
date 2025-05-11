using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Users:BaseEntity
    {
        public string UserName { get; set; }
        public int phone { get; set; }
        public string Email { get; set; }
   
        public string password { get; set; }
        public int RoleId  { get; set; }
        public string RoleName { get; set; }
    }
}
