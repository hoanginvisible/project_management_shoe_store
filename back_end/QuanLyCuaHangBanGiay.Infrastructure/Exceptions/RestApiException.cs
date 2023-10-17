namespace Infrastructure.Exceptions
{
    public class RestApiException : Exception
    {
        public override string Message { get; }
        // public RestApiException() {}

        public RestApiException(string message)
        {
            Message = message;
        }

        public string GetMessage()
        {
            return Message;
        }
    }
}

