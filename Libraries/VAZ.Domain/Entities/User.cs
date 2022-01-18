using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAZ.Domain.Entities
{
	public class User : IdentityUser
	{
		public string Phone { get; set; }
		public string ImagePath { get; set; }
		public int? ShopId { get; set; }
		public Shop Shop { get; set; }
		public ICollection<Product> Products { get; set; }
	}
}
