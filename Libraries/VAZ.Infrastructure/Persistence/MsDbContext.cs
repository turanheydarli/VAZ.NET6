using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAZ.Domain.Entities;

namespace VAZ.Infrastructure.Persistence
{
	public class MsDbContext : IdentityDbContext
	{
		public MsDbContext(DbContextOptions<MsDbContext> options):base(options) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Product>()
				.HasOne(p => p.ProductDetail)
				.WithOne(p => p.Product)
				.HasForeignKey<ProductDetail>(p => p.ProductId);

			builder.Entity<ProductParam>()
				.HasKey(pp => new { pp.ParamId, pp.ProductId });

			builder.Entity<ProductDetail>()
				.HasOne(p => p.Ban)
				.WithMany(b => b.Products)
				.HasForeignKey(p => p.BanId);

			builder.Entity<Media>()
				.HasOne(m => m.Product)
				.WithMany(p => p.Images)
				.HasForeignKey(m => m.ProductId);

			builder.Entity<Media>()
				.HasOne(m => m.Product)
				.WithMany(p => p.Images)
				.HasForeignKey(m => m.ProductId);

			builder.Entity<Shop>()
				.HasOne(s => s.User)
				.WithOne(u => u.Shop)
				.HasForeignKey<User>(u => u.ShopId);

			builder.ApplyConfigurationsFromAssembly(typeof(MsDbContext).Assembly);

			base.OnModelCreating(builder);
		}
	}
}
