using FestivalApp.Core.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Mime;
using System.Text.Json;

namespace FestivalApp.API.Filters
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
                case BadRequestException _:
                    HandleException(context, StatusCodes.Status400BadRequest);
                    break;
                case ForbiddenException _:
                    HandleException(context, StatusCodes.Status403Forbidden);
                    break;
                case NotFoundException _:
                    HandleException(context, StatusCodes.Status404NotFound);
                    break;
                case ValidationException _:
                    HandleException(context, StatusCodes.Status422UnprocessableEntity);
                    break;
                default:
                    HandleException(context, StatusCodes.Status500InternalServerError);
                    break;
            }
        }

        private async void HandleException(ExceptionContext context, int statusCode)
        {
            var reasonPhrase = ReasonPhrases.GetReasonPhrase(statusCode);
            var exception = context.Exception;

            var errorMessage = new
            {
                status = statusCode,
                title = reasonPhrase,
                detail = exception?.Message,
                errors = GetErrors(exception)
            };

            context.HttpContext.Response.StatusCode = statusCode;
            context.HttpContext.Response.ContentType = MediaTypeNames.Application.Json;
            await context.HttpContext.Response.WriteAsync(JsonSerializer.Serialize(errorMessage));

            _logger.LogError(exception, $"{reasonPhrase}: {exception?.Message}; Stack Trace: {exception?.StackTrace}");

            context.ExceptionHandled = true;
        }

        private static IEnumerable<string> GetErrors(Exception exception)
        {
            IEnumerable<string> errors = null;

            if (exception is ValidationException validationException)
            {
                errors = validationException.Errors.Select(e => e.ErrorMessage);
            }

            return errors;
        }
    }
}
