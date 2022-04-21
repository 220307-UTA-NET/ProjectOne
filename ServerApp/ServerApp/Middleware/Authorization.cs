namespace ServerApp.Middleware
{
    public class Authorization
    {
        private readonly RequestDelegate _next;

        public Authorization(RequestDelegate next) { this._next = next; }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Query["authorization"] == "true")
                // keep going
                await _next(context);
            else
            {
                // if Not authorized... then wait
                context.Response.StatusCode = 401;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("error, Not authorized");
            }
        }
    }
}
