using DeliveryOrders.Server.DTO;
using System.Net;
using System.Text.Json;

namespace DeliveryOrders.Server.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (KeyNotFoundException ex)
            {
                await HandleExceptionAsync(httpContext,
                    ex.Message,
                    HttpStatusCode.NotFound,
                    "Selected ID was not found");
            }
            catch (InvalidOperationException ex)
            {
                await HandleExceptionAsync(httpContext,
                    ex.Message,
                    HttpStatusCode.BadRequest,
                    "The pickup date cannot be in the past!");
            }
            catch (ArgumentException ex)
            {
                await HandleExceptionAsync(httpContext,
                    ex.Message,
                    HttpStatusCode.BadRequest,
                    "Address Lines and cities of recipient and sender must not be the same!");
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext,
                    ex.Message,
                    HttpStatusCode.NotFound,
                    "Can't find any data");
            }
        }

        private async Task HandleExceptionAsync(
            HttpContext context,
            string exceptionMessage,
            HttpStatusCode statusCode,
            string message)
        {
            _logger.LogError(exceptionMessage);

            HttpResponse response = context.Response;

            response.ContentType = "application/json";
            response.StatusCode = (int)statusCode;

            ErrorDTO errorDTO = new ErrorDTO()
            {
                Message = message,
                StatusCode = (int)statusCode
            };

            string result = JsonSerializer.Serialize(errorDTO);

            await response.WriteAsJsonAsync(result);
        }
    }
}
