namespace EarlyBird.Packages.Api.Errors
{
    public class BaseResponse
    {
        public List<Error> Errors { get; set; }
        public void AddError(Error error)
        {
            if (Errors == null)
                Errors = new List<Error>();

            Errors.Add(error);
        }
        public void AddError(string title, string code, string propertyName)
        {
            AddError(new Error { Title = title, PropertyName = propertyName, Code = code });
        }
    }
}
