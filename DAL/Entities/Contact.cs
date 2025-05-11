using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Contact : BaseEntity
    {
        public string Facebock { get; set; } public string name { get; set; }
        public string tiktok { get; set; }
        public string twiter { get; set; }
        public string Gamil { get; set; }

        public string linkedin { get; set; }
        public string phone { get; set; }
        public string adderies { get; set; }

    }
}
