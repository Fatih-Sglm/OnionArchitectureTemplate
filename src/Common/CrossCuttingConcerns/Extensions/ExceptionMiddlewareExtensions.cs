using CrossCuttingConcerns.Exceptions;
using Microsoft.AspNetCore.Builder;

namespace CrossCuttingConcerns.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}