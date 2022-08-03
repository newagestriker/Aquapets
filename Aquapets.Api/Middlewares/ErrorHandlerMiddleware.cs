using System.Net;
using System.Text.Json;

namespace Aquapets.Shared.Api.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await response.WriteAsync(result);
            }
        }
    }
}
