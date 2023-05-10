namespace EarlyBird.Packages.Api.Errors
{
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        public Error Error { get; set; }

        public EntityNotFoundException(string sebCustomerNo) : base(sebCustomerNo)
        {

        }
        public EntityNotFoundException() : this(string.Empty)
        {

        }
        public EntityNotFoundException(int id, string entityType, string code)
        {
            Error = new Error { Title = $"Id {id} not found for {entityType}", Code = code };
        }
        public EntityNotFoundException(string sebCustomerNo, string code)
        {
            Error = new Error { Title = $"Customer {sebCustomerNo} not found", Code = code };
        }
    }
}
