using AvaTrade.API.Common;
using AvaTrade.Application.Common;
using System.Net;

namespace AvaTrade.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ApiException ex)
            {
                await HandleApiExceptionAsync(context.Response, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context.Response, ex);
            }
        }

        private async Task HandleApiExceptionAsync(HttpResponse response, ApiException exception)
        {
            response.ContentType = "application/json";
            response.StatusCode = (int)exception.HttpStatusCode;

            var json = ExceptionHandler.GetApiExceptionResponse(exception);

            await response.WriteAsync(json);
        }

        private async Task HandleExceptionAsync(HttpResponse response, Exception exception)
        {
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var apiException = new ApiException("Something went wrong. Please, contact support.", HttpStatusCode.InternalServerError);

            var json = ExceptionHandler.GetApiExceptionResponse(apiException);

            await response.WriteAsync(json);
        }
    }
}
