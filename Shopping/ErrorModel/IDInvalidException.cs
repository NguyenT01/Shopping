namespace Shopping.API.ErrorModel
{
    public class IDInvalidException : Exception
    {
        public IDInvalidException(string message) : base(message) { }
    }
}
