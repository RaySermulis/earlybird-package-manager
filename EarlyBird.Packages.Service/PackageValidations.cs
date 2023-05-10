namespace EarlyBird.Packages.Service
{
    public static class PackageValidations
    {
        private const int MaxHeight = 60;
        private const int MaxWeight = 20;
        private const int MaxLength = 60;
        private const int MaxWidth = 60;

        public static bool PackageIsValid(PackageModel package)
        {
            if (package.Height > MaxHeight || package.Weight > MaxWeight || package.Length > MaxLength || package.Width > MaxWidth)
            {
                return false;
            }

            return true;
        }
    }
}
