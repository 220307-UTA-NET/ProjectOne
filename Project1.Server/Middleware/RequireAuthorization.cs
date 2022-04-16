namespace Project1.Server.Middleware
{
    public class RequireAuthorization
    {
        private readonly RequestDelegate next;
        
        public RequireAuthorization(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Query["authorization"] == true)
            {
                await next(context);
            }
            else
            {
                context.Response.StatusCode = 401;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("error: not authorized");
            }
        }

    }
}
