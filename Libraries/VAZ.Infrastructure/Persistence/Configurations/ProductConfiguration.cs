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
	public class ProductConfiguration : BaseConfiguration<Product>
	{
		public override void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.Property(p => p.Title).HasMaxLength(Convert.ToInt32(MaxLengthSize.Title)).IsRequired();
			builder.Property(p => p.Description).HasMaxLength(Convert.ToInt32(MaxLengthSize.Description)).IsRequired();
			builder.Property(p => p.Price).IsRequired();
			builder.Property(p => p.Slug).IsRequired();
			//builder.Property(p => p.Currency).HasMaxLength(Convert.ToInt32(MaxLengthSize.Currency)).IsRequired();

			base.Configure(builder);
		}
	}
}
