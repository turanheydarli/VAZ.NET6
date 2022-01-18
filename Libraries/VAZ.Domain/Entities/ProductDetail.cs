using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Domain.Common;

namespace VAZ.Domain.Entities
{
	public class ProductDetail : BaseEntity
	{
		public int ProductId { get; set; }
		public Product Product { get; set; }
		public City City { get; set; }
		public ICollection<ProductParam> Params { get; set; }
		public Brand Brand { get; set; }
		public Color Color { get; set; }
		public Engine Engine { get; set; }
		public int BanId { get; set; }
		public Ban Ban { get; set; }
		public Fuel Fuel { get; set; }
		public Gear Gear { get; set; }
		public Transmission Transmission { get; set; }
		public int Power { get; set; }
		public bool IsLoan { get; set; }
		public bool IsBarter { get; set; }
		public long Mileage { get; set; }
		public MileageUnit MileageUnit { get; set; }
		public bool IsNew { get; set; }

	}
}
