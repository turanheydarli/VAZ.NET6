using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VAZ.Domain.Common;
using VAZ.Domain.Entities;

namespace VAZ.Infrastructure.Persistence.Configurations
{
	public class BrandConfiguration : BaseConfiguration<Brand>
	{
		public override void Configure(EntityTypeBuilder<Brand> builder)
		{
			builder.Property(c => c.Name).IsRequired().HasMaxLength(Convert.ToInt32(MaxLengthSize.Name));

			base.Configure(builder);
		}
	}
}
