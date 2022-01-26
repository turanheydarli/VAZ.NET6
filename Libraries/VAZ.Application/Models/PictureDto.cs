using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAZ.Application.Models
{
	public class PictureDto
	{
		public string Caption { get; set; }
		public int FileSize { get; set; }
		public string FileName { get; set; }
		public string MimeType { get; set; }

		public byte[] Picture { get; set; }

	}
}
