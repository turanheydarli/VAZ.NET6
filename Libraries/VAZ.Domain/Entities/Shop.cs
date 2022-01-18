using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Domain.Common;

namespace VAZ.Domain.Entities
{
	public class Shop : BaseEntity
	{
		public User User { get; set; }
		public string Description { get; set; }
		public int ViewCount { get; set; }
	}
}
