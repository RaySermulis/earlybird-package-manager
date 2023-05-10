namespace EarlyBird.Packages.Api.Errors
{
    public class ErrorsException : Exception
    {
        public List<Error> Errors { get; set; }

        public ErrorsException(string title)
        {
            Errors = new List<Error>() { new Error(title) };
        }

        public ErrorsException(string title, string code)
        {
            Errors = new List<Error>() { new Error(title, code) };
        }

        public ErrorsException(string title, string code, int status)
        {
            Errors = new List<Error>() { new Error(title, code, status) };
        }

        public ErrorsException(string title, string code, int status, string type)
        {
            Errors = new List<Error>() { new Error(title, code, status, type) };
        }

        public ErrorsException(string title, string code, int status, string type, string detail)
        {
            Errors = new List<Error>() { new Error(title, code, status, type, detail) };
        }

        public ErrorsException(List<Error> errors)
        {
            Errors = errors;
        }
    }
}
