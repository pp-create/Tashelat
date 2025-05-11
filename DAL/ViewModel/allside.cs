using DAL.Database;
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
    public class QuestionsVM : BaseViewModel
    {

        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public string title { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public string contect { get; set; }
    }
    public class ServicesVM : BaseViewModel
    {
        public string file { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public IFormFile file1 { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public string sidename { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public string contect { get; set; }
    }  public class RepliescostomerVm : BaseViewModel
    {
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public string name { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public string ttile { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public string contect { get; set; }
       
        public string file { get; set; }
        [Required(ErrorMessage = "  برجاء إدخال  هذا الحقل")]
        public IFormFile file1 { get; set; }
    }
  

}
