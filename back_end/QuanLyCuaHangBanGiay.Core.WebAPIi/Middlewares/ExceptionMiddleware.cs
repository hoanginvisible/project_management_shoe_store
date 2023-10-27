using System.Net;
using System.Text.Json;
using QuanLyCuaHangBanGiay.Core.Domain.Resources;
using QuanLyCuaHangBanGiay.Core.WebAPIi.ResponseObjects;

namespace QuanLyCuaHangBanGiay.Core.WebAPIi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public ExceptionMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (BaseCustomException ex)
            {
                context.Response.StatusCode = (int)ex.GetStatusCode(); // Bad Request
                context.Response.ContentType = "application/json";
                var json = JsonSerializer.Serialize(
                    new ErrorResponse(ex.GetStatusCode(), ex.Message));
                await context.Response.WriteAsync(json);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError; // Bad Request
                context.Response.ContentType = "application/json";
                var json = JsonSerializer.Serialize(
                    new ErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
                await context.Response.WriteAsync(json);
            }
        }
    }
}