using web.db.Models;

string connectionString = @"Server=tcp:server1-dbsqlserver.database.windows.net,1433;Initial Catalog=SqlServerDB;Persist Security Info=False;User ID=dbadmin;Password=zhS7S!99rA4!qnd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IProductRepository>(sp => new DTOProductRepository(connectionString));
builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();

app.Run();
