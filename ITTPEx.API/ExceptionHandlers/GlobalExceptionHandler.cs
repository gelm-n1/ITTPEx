using System.ComponentModel.DataAnnotations;
using ITTPEx.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace ITTPEx.API.ExceptionHandlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext context,
            Exception exception,
            CancellationToken cancellationToken)
        {
            (int statusCode, string title) = exception switch
            {
                ValidationException => (400, "Bad Request"),
                InvalidCredentialsException => (401, "Unauthorized"),
                NotFoundException => (404, "Not Found"),
                ForbiddenEditException => (403, "Forbidden"),
                UserAlreadyExistsException => (409, "Conflict"),
                RoleAlreadyExistsException => (409, "Conflict"),
                _ => (500, "Internal Server Error")
            };

            await context.Response.WriteAsJsonAsync(new
            {
                statusCode,
                title,
                detail = exception.Message
            });
            return true;
        }
    }
}
