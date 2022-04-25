// R

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();


var app = builder.Build();


app.UseRouting();
app.UseEndpoints(routeBuilder =>
{
    routeBuilder.MapControllers();
});

app.MapGet("/", () => "Welcome to My Recipe Book!");
app.MapGet("/map1", () => "Map1 Hello World!");
app.MapGet("/map2", () => "Map2 Hello World!");

app.Run();
