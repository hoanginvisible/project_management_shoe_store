using System.Net;
using System.Runtime.Serialization;

namespace QuanLyCuaHangBanGiay.Core.Domain.Resources
{
    public abstract class BaseCustomException : Exception
    {
        protected BaseCustomException()
        {
        }

        protected BaseCustomException(string? message)
            : base(message)
        {
        }

        protected BaseCustomException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        protected BaseCustomException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        public abstract HttpStatusCode GetStatusCode();
    }
}