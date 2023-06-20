using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCleanArchitectureMvc.Application.Interfaces;
using NetCleanArchitectureMvc.Application.Mappings;
using NetCleanArchitectureMvc.Application.Services;
using NetCleanArchitectureMvc.Domain.Entities;
using NetCleanArchitectureMvc.Domain.Interfaces;
using NetCleanArchitectureMvc.Infra.Data.Context;
using NetCleanArchitectureMvc.Infra.Data.Repositories;

namespace NetCleanArchitectureMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
