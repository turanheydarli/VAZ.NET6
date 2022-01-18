using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VAZ.Application.Interfaces;
using VAZ.Application.Services;
using VAZ.Infrastructure.Persistence;
using VAZ.Infrastructure.Persistence.EntityFramework;

namespace VAZ.Application.System
{
	public static class ServiceCollectionExtension
	{
		public static IServiceCollection InjectApplicationServices(this IServiceCollection services)
		{
			services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
			services.AddScoped<IProductService, ProductService>();

			return services;
		}

		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			return services;
		}

		public static IServiceCollection AddCustomizedDataStore(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<MsDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("MsSql"));
			});

			services.AddScoped<DbContext>(provider => provider.GetService<MsDbContext>());

			return services;
		}
	}
}
