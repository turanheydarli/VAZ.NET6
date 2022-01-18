using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Domain.Common;

namespace VAZ.Domain.Entities
{
	public class ProductParam : IEntity
	{
		public int ParamId { get; set; }
		public Param Param { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
	}
}
