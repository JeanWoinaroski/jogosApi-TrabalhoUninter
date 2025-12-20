using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace ProjetoFaculdade.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (KeyNotFoundException knf)
            {
                _logger.LogWarning(knf, "Resource not found");
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Response.ContentType = "application/problem+json";
                var problem = new { type = "https://example.com/not-found", title = "Resource not found", detail = knf.Message };
                await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/problem+json";
                var problem = new { type = "https://example.com/internal-error", title = "An unexpected error occurred", detail = ex.Message };
                await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
            }
        }
    }
}
