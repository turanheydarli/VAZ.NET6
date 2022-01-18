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
	public class ShopConfiguration : BaseConfiguration<Shop>
	{
		public override void Configure(EntityTypeBuilder<Shop> builder)
		{
			builder.Property(s => s.Description).HasMaxLength(Convert.ToInt32(MaxLengthSize.Description)).IsRequired();

			base.Configure(builder);
		}
	}
}
