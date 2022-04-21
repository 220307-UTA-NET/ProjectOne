using StoreApplication.DataLogic;

var builder = WebApplication.CreateBuilder(args);

// Connection String:
// Argument, Hardcoded, File, User Secrets, Environmental Variables
string connectionString = builder.Configuration["connectionString"];

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRepository>(sp => new SqlRepository(connectionString, sp.GetRequiredService<ILogger<SqlRepository>>()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
