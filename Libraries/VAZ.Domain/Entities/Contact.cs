using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Domain.Common;

namespace VAZ.Domain.Entities
{
	public class Contact : BaseEntity
	{
		public string Name { get; set; }
		public City City { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
	}
}
