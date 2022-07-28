namespace Async.Models
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Do something with context near the beginning of request processing.
            // Console.WriteLine("before:" + context.GetHashCode());

            var whatAspNetCoreDie = new WhatAspNetCoreDie();
            var bothAsync = await whatAspNetCoreDie.GetBothAsync("https://www.google.com", "https://www.google.com");
        
            if (bothAsync.Count.Equals(1))
            {
                Console.WriteLine("oh no");
            }

            await _next.Invoke(context);

            // Console.WriteLine("after:"+ context.GetHashCode());
            // Clean up.
        }
    }

    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }
    }
}