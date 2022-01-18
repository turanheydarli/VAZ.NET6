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
	public class ContactConfiguration : BaseConfiguration<Contact>
	{
		public override void Configure(EntityTypeBuilder<Contact> builder)
		{
			builder.Property(c => c.Name).IsRequired().HasMaxLength(Convert.ToInt32(MaxLengthSize.Name));
			builder.Property(c => c.Phone).IsRequired().HasMaxLength(Convert.ToInt32(MaxLengthSize.Phone));
			builder.Property(c => c.Email).IsRequired().HasMaxLength(Convert.ToInt32(MaxLengthSize.Email));

			base.Configure(builder);
		}
	}
}
