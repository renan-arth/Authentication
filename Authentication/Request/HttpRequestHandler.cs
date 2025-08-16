using Authentication.Interfaces;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Authentication.Request
{
    public class HttpRequestHandler
    {
        private readonly ITokenValidator _tokenValidator;
        private readonly ILogger<HttpRequestHandler> _logger;

        public HttpRequestHandler(ITokenValidator tokenValidator, ILogger<HttpRequestHandler> logger)
        {
            _tokenValidator = tokenValidator;
            _logger = logger;
        }

        public async Task HandleAsync(HttpListenerContext context)
        {
            var token = context.Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(token) || !_tokenValidator.IsValid(token))
            {
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";

                var error = JsonSerializer.Serialize(new
                {
                    Error = "Token inválido ou ausente.",
                    timestamp = DateTime.UtcNow
                });

                var bufferError = Encoding.UTF8.GetBytes(error);
                await context.Response.OutputStream.WriteAsync(bufferError);
                context.Response.Close();
                return;
            }

            context.Response.StatusCode = 204;
            context.Response.Close();
        }
    }
}