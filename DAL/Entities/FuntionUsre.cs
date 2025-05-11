using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class FuntionUsre : BaseEntity
    {
       
        public  Guid userid { get; set; }
        public string namefuntion { get; set; }
     
    }
}

