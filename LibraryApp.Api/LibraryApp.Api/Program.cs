using LibraryApp.DataLogias;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

//Connection String
var connectionString = builder.Configuration.GetConnectionString("connectionString");
//var connectionString = builder.Configuration["connectionString"];

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRepository>(sp => new SQLRepository(connectionString, sp.GetRequiredService<ILogger<SQLRepository>>()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
