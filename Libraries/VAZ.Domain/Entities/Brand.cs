using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Domain.Common;

namespace VAZ.Domain.Entities
{
	public class Brand : BaseEntity
	{
		public string Name { get; set; }
		public ICollection<ProductDetail> Products { get; set; }
	}
}
