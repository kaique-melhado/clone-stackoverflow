using MySqlConnector;
using System.Net;

namespace CloneStackOverflow.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
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
            catch (MySqlException ex)
            {
                _logger.LogError($"A MySQL error occurred: {ex.Message}");
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var message = "An error occurred while processing your request. Please try again later.";

            if (exception is MySqlException)
                message = "We're currently experiencing database issues. Please try again later.";

            context.Session.SetString("ErrorMessage", message);
            context.Response.Redirect("/Home/Error");

            return Task.CompletedTask;
        }
    }
}
