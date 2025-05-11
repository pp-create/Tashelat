using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class MassagerUesrs : BaseEntity
    {
        public string name { get; set; }
        public string gamil { get; set; }
        public string title { get; set; }
        public string massage { get; set; }
       
    }
}
