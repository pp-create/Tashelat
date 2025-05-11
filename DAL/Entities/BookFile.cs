using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class BookFile:BaseEntity
    {
       
		//public int MyProperty { get; set; }
		public Guid FK_ImportBook { get; set; }
	
		public string Name { get; set; }
		public string url { get; set; }	
		public string Answer { get; set; }	public string Title { get; set; }
	}
}
