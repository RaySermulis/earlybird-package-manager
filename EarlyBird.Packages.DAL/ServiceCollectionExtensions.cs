using EarlyBird.Packages.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EarlyBird.Packages.DAL
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDAL(this IServiceCollection services)
        {
            services.AddTransient<IPackageRepository, PackageRepository>();
        }
    }
}
