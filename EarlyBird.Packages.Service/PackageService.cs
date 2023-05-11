using EarlyBird.Packages.DAL.Mappers;
using EarlyBird.Packages.DAL.Repositories;

namespace EarlyBird.Packages.Service
{
    public interface IPackageService
    {
        List<PackageModel> GetAllPackages();
        PackageModel GetPackageDetails(int kolliid);
        bool CreatePackage(PackageModel package);
    }

    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;

        public PackageService(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public List<PackageModel> GetAllPackages()
        {
            var packages = _packageRepository.GetAllPackages();
            return packages.Select(PackageMapper.ToModel).ToList();
        }

        public PackageModel GetPackageDetails(int kolliid)
        {
            return PackageMapper.ToModel(_packageRepository.GetPackageDetails(kolliid));
        }

        public bool CreatePackage(PackageModel package)
        {
            return _packageRepository.CreatePackage(PackageMapper.ToEntity(package));
        }
    }
}