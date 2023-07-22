using Service1.Middlewares;

namespace Service1.Extensions;

public static class GlobalExceptionExtension
{
    public static IApplicationBuilder UseGlobalException(this IApplicationBuilder app)
    {
        return app.UseMiddleware<GlobalExceptionMiddleware>();
    }
}