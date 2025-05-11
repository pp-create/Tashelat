using DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModel
{
    public class AboutVM : BaseViewModel
    {
      

        public string file { get; set; }
       
        public IFormFile file1 { get; set; }
      
        public string description { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public string message { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public string goal { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public string Vision { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public int Employes { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public int company { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public string services { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]

        public string users { get; set; }
    }
    public class MassagerUesrsVM : BaseViewModel
    {
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public string name { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public string gamil { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public string title { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public string massage { get; set; }


    }  public class RequestVM 
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        // public byte[]? ConcurrencyStamp { get; set; } 
        public bool IsDeleted { get; set; }
        public string idcustomer { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public string name { get; set; }
        public Guid? userId { get; set; }
        public string Status { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public string nid { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public string phone { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public string type { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public string livesin { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public string salary { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public string namebank { get; set; }


    }
    public class ContactVM : BaseViewModel
    {
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]

        public string name { get; set; } [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]

        public string Facebock { get; set; }
        [Required(ErrorMessage = "برجاء إدخال ")]
        public string tiktok { get; set; }
        [Required(ErrorMessage = "برجاء إدخال ")]
        public string twiter { get; set; }
        [Required(ErrorMessage = "برجاء إدخال ")]
        public string Gamil { get; set; }
        [Required(ErrorMessage = "برجاء إدخال ")]

        public string linkedin { get; set; }
        [Required(ErrorMessage = "برجاء إدخال ")]
        public string phone { get; set; }
        [Required(ErrorMessage = "برجاء إدخال ")]
        public string adderies { get; set; }

        
    }
    }
