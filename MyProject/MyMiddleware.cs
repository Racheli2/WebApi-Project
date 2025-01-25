namespace MyProject;

    public class MyMiddleware
    {
        private RequestDelegate next;
 
        public MyMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("wellcome to my middleware!\n");
            await Task.Delay(1000);
            await next.Invoke(httpContext);
            await httpContext.Response.WriteAsync("middleware end!\n");        
        }
    }

    public static partial class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }
    }

