using FestivalApp.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Mime;
using System.Text.Json;

namespace FestivalApp.API.ExceptionFilter
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            switch ( context.Exception )
            {
                case NotFoundException _:
                    HandleException(context, StatusCodes.Status404NotFound);
                    break;
                case BadRequestException _:
                    HandleException(context, StatusCodes.Status400BadRequest);
                    break;
                default:
                    _logger.LogError(context.Exception, $"Unhandled error occured: {context.Exception.Message}; Stack Trace: {context.Exception.StackTrace}");
                    break;
            }
        }

        private void HandleException(ExceptionContext context, int statusCode)
        {
            var reasonPhrase = ReasonPhrases.GetReasonPhrase(statusCode);
            var exception = context.Exception;

            var errorMessage = JsonSerializer.Serialize(new ProblemDetails
            {
                Status = statusCode,
                Title = reasonPhrase,
                Detail = exception?.Message
            });

            context.HttpContext.Response.StatusCode = statusCode;
            context.HttpContext.Response.ContentType = MediaTypeNames.Application.Json;
            context.HttpContext.Response.WriteAsync(errorMessage);

            _logger.LogError(exception, $"{reasonPhrase}: {exception?.Message}; Stack Trace: {exception?.StackTrace}");

            context.ExceptionHandled = true;
        }
    }
}
