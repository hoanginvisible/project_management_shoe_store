using System.Net;

namespace QuanLyCuaHangBanGiay.Core.WebAPIi.ResponseObjects
{
    public class SuccessReponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public object? Data { get; set; }
        public string Message { get; set; }

        public SuccessReponse(HttpStatusCode statusCode, object? data, string message)
        {
            StatusCode = statusCode;
            Data = data;
            Message = message;
        }
    }
}