using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModel
{
    public class ReadingVM:BaseViewModel
    {
        public Guid FK_SenderId { get; set; }

        public Guid FK_ReseverId { get; set; }
        public Guid FK_LastMassage { get; set; }

        public bool Seeen { get; set; }
        public string Resever { get; set; }
        public string sender { get; set; }
        public string descrption { get; set; }
        public string subject { get; set; }
        public string BookType { get; set; }
        public string? Image { get; set; }
        public IFormFile? files;




    }
}
