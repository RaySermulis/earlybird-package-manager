namespace EarlyBird.Packages.Api.Errors
{
    public class Error
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int? Status { get; set; }
        public string Detail { get; set; }
        public string Code { get; set; }
        public string PropertyName { get; set; }
        public Error()
        {

        }
        public Error(string title)
        {
            Title = title;
        }
        public Error(string title, string code)
        {
            Title = title;
            Code = code;
        }
        public Error(string title, string code, int status)
        {
            Title = title;
            Code = code;
            Status = status;
        }
        public Error(string title, string code, int status, string type)
        {
            Code = code;
            Type = type;
            Title = title;
            Status = status;
        }
        public Error(string title, string code, int status, string type, string detail)
        {
            Code = code;
            Type = type;
            Title = title;
            Code = code;
            Status = status;
            Detail = detail;
        }
        public Error(string title, string code, int status, string type, string detail, string propertyName)
        {
            Type = type;
            Title = title;
            Code = code;
            Status = status;
            Detail = detail;
            PropertyName = propertyName;
        }
    }
}
