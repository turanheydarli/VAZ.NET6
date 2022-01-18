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
	public class GearConfiguration : BaseConfiguration<Gear>
	{
		public override void Configure(EntityTypeBuilder<Gear> builder)
		{
			builder.Property(g => g.Name).IsRequired().HasMaxLength(Convert.ToInt32(MaxLengthSize.Name));

			base.Configure(builder);
		}
	}
}
