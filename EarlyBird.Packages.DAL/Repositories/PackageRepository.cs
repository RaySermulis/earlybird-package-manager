using EarlyBird.Packages.DAL.Models;

namespace EarlyBird.Packages.DAL.Repositories
{
    public interface IPackageRepository
    {
        Task<List<Package>> GetAllPackages();
    }
    public class PackageRepository : IPackageRepository
    {

        public async Task<List<Package>> GetAllPackages()
        {
            return await Packages();
        }

        private Task<List<Package>> Packages() => Task.FromResult<List<Package>>(new List<Package>
        {
            new Package {Kolliid = 1, Height = 5, Length = 10, Weight = 10, Width = 30},
            new Package {Kolliid = 2, Height = 15, Length = 20, Weight = 15, Width = 40},
            new Package {Kolliid = 3, Height = 25, Length = 30, Weight = 20, Width = 60}
        });
    }
}
