using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Services:BaseEntity
    {
        public string sidename { get; set; }public string contect{ get; set; } public string file { get; set; }
    }
    public class Repliescostomer : BaseEntity
    {
        public string name { get; set; } public string ttile { get; set; }
        public string contect { get; set; }
        public string file { get; set; }
    }
}
