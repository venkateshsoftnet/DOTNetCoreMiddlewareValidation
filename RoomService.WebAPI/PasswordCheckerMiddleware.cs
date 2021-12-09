using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace RoomService.WebAPI
{
    public class PasswordCheckerMiddleware
    {
        private readonly RequestDelegate _next;
        public PasswordCheckerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            var passwordKey = context.Request.Headers["passwordKey"];
            if (string.IsNullOrWhiteSpace(passwordKey) ||
                passwordKey != "passwordKey123456789")
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;

                return;
            }

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }
}
