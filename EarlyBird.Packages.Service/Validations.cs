namespace EarlyBird.Packages.Service
{
    public static class Validations
    {
        private const int MaxHeight = 60;
        private const int MaxWeight = 20;
        private const int MaxLength = 60;
        private const int MaxWidth = 60;

        //todo return dimension errors
        public static bool PackageIsValid(PackageModel package)
        {
            return !(package.Height > MaxHeight) && !(package.Weight > MaxWeight) && !(package.Length > MaxLength) && !(package.Width > MaxWidth);
        }

        public static bool IsSearchKolliidValid(string kolliid)
        {
            var isValid = IsDigitsOnly(kolliid) && kolliid.StartsWith("999") && kolliid.Length == 18;
            return isValid;
        }

        private static bool IsDigitsOnly(string str)
        {
            return str.All(c => c is >= '0' and <= '9');
        }
    }
}