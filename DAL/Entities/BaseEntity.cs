using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }=DateTime.Now;
       // public byte[]? ConcurrencyStamp { get; set; } 
        public bool IsDeleted { get; set; }
    }
}