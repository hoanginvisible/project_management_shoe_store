using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Exceptions
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
            catch (RestApiException ex)
            {
                context.Response.StatusCode = 400; // Bad Request
                context.Response.ContentType = "application/json";
                var json = JsonSerializer.Serialize(new { message = ex.GetMessage() });
                await context.Response.WriteAsync(json);
            }
        }
    }
}