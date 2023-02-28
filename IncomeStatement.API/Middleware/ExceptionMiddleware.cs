using IncomeStatement.API.Responses;
using System.Text.Json;

namespace IncomeStatement.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private ILogger<ExceptionMiddleware>? _logger;

        public ExceptionMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger = context.RequestServices
                .GetRequiredService<ILogger<ExceptionMiddleware>>();

            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                _logger.LogError("{error}", ex);
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            var error = new ErrorResponse
            {
                Status = context.Response.StatusCode,
                Message = "An unexpected error occured"
            };

            var json = JsonSerializer.Serialize(error);
            
            if (!string.IsNullOrEmpty(json))
                await context.Response.WriteAsync(json);

        }
    }
}
