namespace Async.Models
{
    public class DemoMiddleware
    {
        private readonly RequestDelegate _next;

        public DemoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Console.WriteLine("before:" + SynchronizationContext.Current.GetHashCode());

            var demoClient = new DemoClientCore();
            var bothAsync = (await demoClient.GetBothAsync("https://www.google.com", "https://www.google.com")).ToList();

            if (bothAsync.Count.Equals(1))
            {
                throw new ThreadRunParallelException("oh no, Thread run together!!!");
            }

            await _next.Invoke(context);

            // Console.WriteLine("after:" + SynchronizationContext.Current.GetHashCode());
        }
    }

    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DemoMiddleware>();
        }
    }
}