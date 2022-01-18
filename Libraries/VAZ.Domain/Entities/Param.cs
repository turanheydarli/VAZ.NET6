using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Domain.Common;

namespace VAZ.Domain.Entities
{
	public class Param : BaseEntity
	{
		public string Name { get; set; }
		public string Icon { get; set; }
	}
}
