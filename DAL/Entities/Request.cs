using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Request 
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        // public byte[]? ConcurrencyStamp { get; set; } 
        public bool IsDeleted { get; set; }
        public string name { get; set; }
        public string idcustomer { get; set; }
        public string nid { get; set; }
        public string Status { get; set; }
        public string phone { get; set; }
        public string type { get; set; } public string livesin { get; set; }
        public string salary { get; set; }
        public string namebank { get; set; }  public Guid? userId { get; set; }

    }
}
