using EarlyBird.Packages.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace EarlyBird.Packages.Service
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddTransient<IPackageService, PackageService>();
            services.RegisterDAL();
        }
    }
}
