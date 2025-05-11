using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModel
{
    public class HomepageViewModel : BaseViewModel
    {
        public string Name { get; set; }
        //

        public string Image { get; set; }
        public string titile { get; set; }

        public string Ancswer { get; set; }
        public IFormFile Supplierphoto { get; set; }
       

        public List<Data>? files;
     
    }public class filebbookViewModel : BaseViewModel
    {
        public Guid FK_ImportBook { get; set; }

        public string Name { get; set; }
        public string url { get; set; }
        public IFormFile Files { get; set; }
        public string Answer { get; set; }
        public string Title { get; set; }
    }


   public class Data: BaseViewModel
    {
    public IFormFile Files { get; set; }
    public string Title { get; set; }
    public string Answer { get; set; }
    public string Url { get; set; }
}
}
