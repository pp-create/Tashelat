using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class About : BaseEntity
    {


     
        public string file { get; set; }
       
        public string description { get; set; }
        public string message{ get; set; }
        public string goal { get; set; }
        public string Vision { get; set; }
        public int Employes { get; set; }
        public int company { get; set; }
        public string services { get; set; }
        public string users { get; set; }
     }


    
}
