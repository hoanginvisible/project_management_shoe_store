using System.Net;
using System.Runtime.Serialization;
using QuanLyCuaHangBanGiay.Core.Domain.Resources;

namespace QuanLyCuaHangBanGiay.Core.Domain.Exceptions
{
    public class ValidationFailedException : BaseCustomException
    {
        public ValidationFailedException()
        {
        }

        public ValidationFailedException(string? message) : base(message)
        {
        }

        public ValidationFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ValidationFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public override HttpStatusCode GetStatusCode()
        {
            throw new NotImplementedException();
        }
    }
}