namespace Infrastructure.Exceptions
{
    public class RestApiException : Exception
    {
        public RestApiException(string message) : base(message)
        {
        }
    }
}