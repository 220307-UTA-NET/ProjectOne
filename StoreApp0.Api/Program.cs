using StoreApp0.DataLogic;

var builder = WebApplication.CreateBuilder(args);

//string connectionString = builder.Configuration.GetConnectionString("connectionString");
//IConfiguration configuration = new ConfigurationBinder().AddJsonFile("appsettings.json").Build();
//var connectionString = builder.Configuration.GetConnectionString("CustomerDB");
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddScoped<IRepository, SqlRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Store App", Version = "v1" });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "Store App v1"));
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.UseEndpoints(ep => {
    ep.MapControllers();
});

app.Run();

