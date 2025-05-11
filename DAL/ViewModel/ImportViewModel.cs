using DAL;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class ImportViewModel : BaseViewModel
	{
		public string DestinationName { get; set; }
		public string BookNumber { get; set; }
		public string SupplierName { get; set; }
        public string BookType { get; set; }

        public string DestinationNameSendTo { get; set; }
        public Guid circleId { get; set; }
        public Guid SendcircleId { get; set; }
        public string SupplierImage { get; set; }
        public IFormFile Supplierphoto { get; set; }
        //ناقص اضافة الصور
        public List<string>ImageName { get; set; }=new List<string>();
        [Required]
        public List<IFormFile>? Images { get; set; } = null;

        //[JsonIgnore]
        //[JsonIgnore]
        //public List<ProductCategoryViewModel> ProductCategories { get; set; }
        // public List<ProductViewModel> Products { get; set; }
    }
}
