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
        private readonly IPackageRepository _packageRepository;

        public PackageService(IPackageRepository packageRepository)
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