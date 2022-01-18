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
	public class TransmissionConfiguration : BaseConfiguration<Transmission>
	{
		public override void Configure(EntityTypeBuilder<Transmission> builder)
		{
			builder.Property(t => t.Name).HasMaxLength(Convert.ToInt32(MaxLengthSize.Name)).IsRequired();

			base.Configure(builder);
		}
	}
}
