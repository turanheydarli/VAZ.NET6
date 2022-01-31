using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Domain.Common;

namespace VAZ.Domain.Entities
{
	public class Picture : BaseEntity
	{
		public string Caption { get; set; }
		public long FileSize { get; set; }
		public string FileName { get; set; }
		public string MimeType { get; set; }
		public int ProductId { get; set; }

	}
}
