using Aquapets.Shared.Infrastructure.Exceptions;
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
                switch(error)
                {
                    case FirebaseLoginException _:
                    case FirebaseRegisterException _:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;

                }
               
                response.ContentType = "application/json";

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                
                await response.WriteAsync(result);
            }
        }
    }
}
