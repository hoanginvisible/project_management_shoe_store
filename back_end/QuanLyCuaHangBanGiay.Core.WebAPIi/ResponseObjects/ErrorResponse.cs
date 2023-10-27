using System.Net;

namespace QuanLyCuaHangBanGiay.Core.WebAPIi.ResponseObjects
{
    public class ErrorResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }

        public ErrorResponse(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}