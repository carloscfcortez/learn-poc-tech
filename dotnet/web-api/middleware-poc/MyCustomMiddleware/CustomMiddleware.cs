namespace middleware_poc.MyCustomMiddleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
        }
    }

    public static class RequestCustomMiddleware
    {
        public static IApplicationBuilder UseCustomerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}