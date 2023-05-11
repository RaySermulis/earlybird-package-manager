using EarlyBird.Packages.DAL.Models;
using Microsoft.Extensions.Caching.Memory;

namespace EarlyBird.Packages.DAL.Repositories
{
    public interface IPackageRepository
    {
        List<Package> GetAllPackages();
        Package GetPackageDetails(int kolliid);
        bool CreatePackage(Package package);
    }

    public class PackageRepository : IPackageRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions memoryCacheEntryOptions;

        public PackageRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            memoryCacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(new TimeSpan(0, 60, 0));
        }

        public List<Package> GetAllPackages()
        {
            var packages = GetCachePackages();
            return packages?.SelectMany(x => x.Values).ToList() ?? new List<Package>();
        }

        public Package GetPackageDetails(int kolliid)
        {
            var details = GetAllPackages()?.FirstOrDefault(x => x.Kolliid == kolliid);
            return details;
        }

        public bool CreatePackage(Package package)
        {
            var packageDetails = GetPackageDetails(package.Kolliid);
            if (packageDetails != null)
            {
                throw new Exception("error: package already exists");
            }

            var packages = GetCachePackages() ?? new List<Dictionary<int, Package>>();
            if (packages.Any(x => x.ContainsKey(package.Kolliid)))
            {
                throw new Exception("error: package already exists");
            }
            packages.Add(new Dictionary<int, Package> { { package.Kolliid, package } });
            _memoryCache.Set("packages", packages, memoryCacheEntryOptions);
            return true;
        }

        private List<Dictionary<int, Package>> GetCachePackages()
        {
            _memoryCache.TryGetValue("packages", out List<Dictionary<int, Package>> packages);
            return packages;
        }
    }
}
