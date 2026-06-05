using CarRentalManagementSystem.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagementSystem.Api.Middleware
{
    public sealed class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
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
            catch (ConflictException exception)
            {
                await WriteProblemDetailsAsync(
                    context,
                    StatusCodes.Status409Conflict,
                    "Conflict",
                    exception.Message);
            }
            catch (ValidationException exception)
            {
                await WriteProblemDetailsAsync(
                    context,
                    StatusCodes.Status400BadRequest,
                    "Validation Error",
                    exception.Message);
            }
            catch (NotFoundException exception)
            {
                await WriteProblemDetailsAsync(
                    context,
                    StatusCodes.Status404NotFound,
                    "Not Found",
                    exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unhandled exception occurred.");

                await WriteProblemDetailsAsync(
                    context,
                    StatusCodes.Status500InternalServerError,
                    "Server Error",
                    "An unexpected error occurred.");
            }
        }
        private static async Task WriteProblemDetailsAsync(
            HttpContext context,
            int statusCode,
            string title,
            string detail)
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/problem+json";

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = detail,
                Instance = context.Request.Path
            };

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
