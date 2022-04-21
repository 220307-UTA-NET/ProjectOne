using OlympicGames.DataLogic;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("connection");
//string connection = builder.Configuration["connection"];

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRepository>(sp => new SQLRepository(connection, sp.GetRequiredService<ILogger<SQLRepository>>()));

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();