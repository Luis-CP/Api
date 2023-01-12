public class TimeMiddle
{
    readonly RequestDelegate next;

    public TimeMiddle(RequestDelegate nextRequest)
    {
        next = nextRequest;
    }

    public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
    {
        await next(context);

        if(context.Request.Query.Any(p=> p.Key=="time"))
        {
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());  
        }    
    }
}

    public static class TimeMiddleExtencion
    {
        public static IApplicationBuilder UseTimeMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddle>();
        }
    }