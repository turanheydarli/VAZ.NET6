using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Domain.Common;

namespace VAZ.Domain.Entities
{
	public class Product : BaseEntity
	{
		public string Title { get; set; }
		public string Slug { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public Currency Currency { get; set; }
		public ProductDetail ProductDetail { get; set; }
		public int ViewCount { get; set; }
		public string Contact { get; set; }
		public ICollection<Picture> Pictures { get; set; }
		public bool IsPro { get; set; }
		public bool IsVip { get; set; }
		
	}
}
