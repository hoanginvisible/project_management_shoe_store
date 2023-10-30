using System.Net;
using System.Runtime.Serialization;
using QuanLyCuaHangBanGiay.Core.Domain.Resources;

namespace QuanLyCuaHangBanGiay.Core.Domain.Exceptions
{
    public class NotFoundException : BaseCustomException
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string? message) : base(message)
        {
        }

        public NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public override HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.NotFound;
        }
    }
}