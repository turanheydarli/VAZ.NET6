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
	public class MediaConfiguration : BaseConfiguration<Picture>
	{
		public override void Configure(EntityTypeBuilder<Picture> builder)
		{
			builder.Property(m => m.FileSize).IsRequired();
			builder.Property(m => m.FileName).IsRequired().HasMaxLength(Convert.ToInt32(MaxLengthSize.FileName));

			base.Configure(builder);
		}
	}
}
