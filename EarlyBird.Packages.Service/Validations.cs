namespace EarlyBird.Packages.Service
{
    public static class Validations
    {
        private const int MaxHeight = 60;
        private const int MaxWeight = 20;
        private const int MaxLength = 60;
        private const int MaxWidth = 60;

        public static List<string> ValidateDimensions(PackageModel package)
        {
            var errors = new List<string>();
            if (package.Height > MaxHeight) errors.Add($"MaxHeight: {MaxHeight}");
            if (package.Weight > MaxWeight) errors.Add($"MaxWeight: {MaxWeight}");
            if (package.Length > MaxLength) errors.Add($"MaxLength: {MaxLength}");
            if (package.Width > MaxWidth)   errors.Add($"MaxWidth: {MaxWidth}");

            return errors;
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