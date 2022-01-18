using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Domain.Common;
using VAZ.Domain.Entities;

namespace VAZ.Infrastructure.Persistence.Configurations
{
	public class CityConfiguration : BaseConfiguration<City>
	{
		public override void Configure(EntityTypeBuilder<City> builder)
		{
			builder.Property(c => c.Name).IsRequired().HasMaxLength(Convert.ToInt32(MaxLengthSize.Name));

			base.Configure(builder);
		}
	}
}
