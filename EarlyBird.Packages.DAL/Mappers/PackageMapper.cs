using EarlyBird.Packages.DAL.Models;
using EarlyBird.Packages.Service;

namespace EarlyBird.Packages.DAL.Mappers
{
    public static class PackageMapper
    {
        public static PackageModel ToModel(Package package)
        {
            return new PackageModel
            {
                Kolliid = package.Kolliid.ToString(),
                Height = package.Height,
                Width = package.Width,
                Length = package.Length,
                Weight = package.Weight
            };
        }

        public static Package ToEntity(PackageModel model)
        {
            return new Package
            {
                Kolliid = int.Parse(model.Kolliid),
                Height = model.Height,
                Width = model.Width,
                Length = model.Length,
                Weight = model.Weight
            };
        }
    }
}
