using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Domain.Common;

namespace VAZ.Domain.Entities
{
	public class ProductMedia : IEntity
	{
		public int ProductId { get; set; }
		public Product Product { get; set; }
		public int PicturId { get; set; }
		public Picture Picture { get; set; }
	}
}
