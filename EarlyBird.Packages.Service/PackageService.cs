using EarlyBird.Packages.DAL.Models;
using EarlyBird.Packages.DAL.Repositories;

namespace EarlyBird.Packages.Service
{
    public interface IPackageService
    {
        Task<List<Package>> GetAllPackages();
        void GetPackageDetails();
        void CreatePackage();
    }

    public class PackageService : IPackageService
    {
        private PackageRepository _packageRepository;

        public PackageService(PackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<List<Package>> GetAllPackages()
        {
            return await _packageRepository.GetAllPackages();
        }

        public void GetPackageDetails()
        {
            throw new NotImplementedException();
        }

        public void CreatePackage()
        {
            throw new NotImplementedException();
        }
    }
}