using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Domain.Common;

namespace VAZ.Domain.Entities
{
	public class Media : BaseEntity
	{
		public string Caption { get; set; }

		public int FileSize { get; set; }

		public string FileName { get; set; }

		public MediaType MediaType { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
	}
}
