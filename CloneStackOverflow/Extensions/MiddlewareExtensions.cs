using CloneStackOverflow.Middlewares;

namespace CloneStackOverflow.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<NotFoundMiddleware>();
            app.UseMiddleware<CustomExceptionMiddleware>();

            return app;
        }
    }
}
