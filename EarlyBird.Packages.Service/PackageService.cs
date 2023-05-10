using EarlyBird.Packages.DAL.Mappers;
using EarlyBird.Packages.DAL.Models;
using EarlyBird.Packages.DAL.Repositories;

namespace EarlyBird.Packages.Service
{
    public interface IPackageService
    {
        Task<List<PackageModel>> GetAllPackages();
        Task<PackageModel> GetPackageDetails(int kolliid);
        Task CreatePackage(PackageModel package);
    }

    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;

        public PackageService(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<List<PackageModel>> GetAllPackages()
        {
            var packages = _packageRepository.GetAllPackages();
            return packages.Result.Select(PackageMapper.ToModel).ToList();
        }

        public async Task<PackageModel> GetPackageDetails(int kolliid)
        {
            return PackageMapper.ToModel(await _packageRepository.GetPackageDetails(kolliid));
        }

        public async Task CreatePackage(PackageModel package)
        {
            await _packageRepository.CreatePackage(PackageMapper.ToEntity(package));
        }
    }
}