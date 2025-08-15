using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NKatmanliMimariOrnegi.Business.Interfaces;
using NKatmanliMimariOrnegi.Business.Services;
using NKatmanliMimariOrnegi.DataAccess.Contexts;
using NKatmanliMimariOrnegi.DataAccess.Interfaces;
using NKatmanliMimariOrnegi.DataAccess.Repositories;

namespace NKatmanliMimariOrnegi.Business.DependencyResolvers.Microsoft;

public static class DependencyExtension
{
    public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<NKatmanliMimariOrnegiDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        });
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IProductService,ProductService>();
    }
}
