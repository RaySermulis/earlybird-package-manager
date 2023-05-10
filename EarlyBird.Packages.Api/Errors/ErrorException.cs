namespace EarlyBird.Packages.Api.Errors
{
    public class ErrorException : Exception
    {
        public Error Error { get; set; }

        public ErrorException(string title)
        {
            Error = new Error(title);
        }
        public ErrorException(string title, string code)
        {
            Error = new Error(title, code);
        }
        public ErrorException(string title, string code, int status)
        {
            Error = new Error(title, code, status);
        }
        public ErrorException(string title, string code, int status, string type)
        {
            Error = new Error(title, code, status, type);
        }
        public ErrorException(string title, string code, int status, string type, string detail)
        {
            Error = new Error(title, code, status, type, detail);
        }
    }
}
