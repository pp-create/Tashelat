using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Import : BaseEntity
    {
        public string DestinationName { get; set; }
        public string BookNumber { get; set; }
        public string SupplierName  { get; set; }
        public string BookType { get; set; }

        public string DestinationNameSendTo { get; set; }
        public Guid circleId { get; set; }
        public Guid SendcircleId { get; set; }

        public string? SupplierImage { get; set; }
        //ناقص اضافة الصور

        // public List<ProductCategory> ProductCategories { get; set; }
    }
}