var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

//app.Use(async(context, next) =>
//{
//    if (context.Request.Query["authorization"] == true)
//    {
//        await next(context);
//    }
//    else
//    {
//        context.Response.StatusCode = 401;
//        context.Response.ContentType = "text/plain";
//        await context.Response.WriteAsync("error: not authorized");
//    }
//});
app.UseRouting();
app.UseEndpoints(routeBuilder =>
{
    routeBuilder.MapControllers();
});


app.MapGet("/", () => "Hello! Welcome to Kevin Lee's Bank!");
app.MapGet("/user", () => "Type here to register");
app.MapGet("/account", () => "Type here to see your banking account");

app.Run();
