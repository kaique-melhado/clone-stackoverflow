namespace CloneStackOverflow.Middlewares
{
    public class NotFoundMiddleware
    {
        private readonly RequestDelegate _next;

        public NotFoundMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == 404)
                await HandleNotFoundAsync(context);
        }

        private Task HandleNotFoundAsync(HttpContext context)
        {
            context.Session.SetString("ErrorMessage", "The page you requested was not found.");
            context.Response.Redirect("/Home/Error");

            return Task.CompletedTask;
        }
    }
}
