using MuseumVisit.DataLogic;
using Microsoft.EntityFrameworkCore;
using MuseumVisit.BusinessLogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// for work at home 
// var connectionString = builder.Configuration.GetConnectionString("AppConfig");

//for deployment
var connectionString = builder.Configuration.GetConnectionString("RPS-DB-Connection");

//builder.Host.ConfigureAppConfiguration(builder =>
//{
//    //Connect to your App Config Store using the connection string
//    builder.AddAzureAppConfiguration(connectionString);
//})
//            .ConfigureServices(services =>
//            {
//                services.AddControllersWithViews();
//            });

//builder.Configuration.AddEnvironmentVariables(prefix: "MyCustomPrefix_");

//string connectionString = builder.Configuration["connectionString"];

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddDbContext<PersonContext>(opt =>
//    opt.UseInMemoryDatabase("PersonList"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRepository>(sp => new SQLRepository(connectionString, sp.GetRequiredService<ILogger<SQLRepository>>()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//}
app.UseStaticFiles();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

