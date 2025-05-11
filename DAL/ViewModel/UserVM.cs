using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModel
{
    public class UserVM:BaseViewModel
    {
        public string UserName { get; set; }
        public int phone { get; set; }
        public string CreationDate { get; set; }
        public string Email { get; set; }
        [PasswordPropertyText]
        public string password { get; set; }
        public int RoleId { get; set; }
        public List<string> funtion { get; set; }
        public string RoleName { get; set; }
    }
}
