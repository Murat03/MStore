using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Concrete;
using Repositories.Contracts;
using Services.Concrete;
using Services.Contracts;

namespace StoreApp.Infrastructure.Extensions
{
	public static class ServiceExtension
	{
		public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<RepositoryContext>(options => {
				options.UseSqlServer(configuration.GetConnectionString("mssqlconnection"),
					b => b.MigrationsAssembly("StoreApp"));
			});
		}
		public static void ConfigureRepositoryRegistration(this IServiceCollection services)
		{
			services.AddScoped<IRepositoryManager, RepositoryManager>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
		}
		public static void ConfigureServiceRegistration(this IServiceCollection services)
		{
			services.AddScoped<IServiceManager, ServiceManager>();
			services.AddScoped<IProductService, ProductManager>();
			services.AddScoped<ICategoryService, CategoryManager>();
		}
	}
}
