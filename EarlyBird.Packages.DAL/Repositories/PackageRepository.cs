using EarlyBird.Packages.DAL.Models;

namespace EarlyBird.Packages.DAL.Repositories
{
    public interface IPackageRepository
    {
        Task<List<Package>> GetAllPackages();
        Task<Package> GetPackageDetails(int kolliid);

        Task CreatePackage(Package package);
    }

    public class PackageRepository : IPackageRepository
    {
        public async Task<List<Package>> GetAllPackages()
        {
            return await Packages();
        }

        public Task<Package> GetPackageDetails(int kolliid)
        {
            var details = Packages().Result.FirstOrDefault(x => x.Kolliid == kolliid);
            if (details != null)
            {
                return Task.FromResult(details);
            }

            return null;
        }

        public Task CreatePackage(Package package)
        {
            if (GetPackageDetails(package.Kolliid) is not null)
            {
                throw new Exception("error: package already exists");
            }

            return Task.CompletedTask;
        }

        private Task<List<Package>> Packages() => Task.FromResult<List<Package>>(new()
        {
            new() {Kolliid = 1, Height = 5, Length = 10, Weight = 10, Width = 30},
            new() {Kolliid = 2, Height = 15, Length = 20, Weight = 15, Width = 40},
            new() {Kolliid = 3, Height = 25, Length = 30, Weight = 20, Width = 60}
        });
    }
}
