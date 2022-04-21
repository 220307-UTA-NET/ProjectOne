using StoreApplication.DataLogic;

var builder = WebApplication.CreateBuilder(args);

// Connection String:
// Argument, Hardcoded, File, User Secrets, Environmental Variables
string connectionString = builder.Configuration["connectionString"];

//string connectString = builder.Configuration["connectString"]; THIS IS ONE IS FOR DEBUG
// string connectString = builder.Configuration.GetConnectionString("connectionString); THIS ONE FOR AZURE DEPLOYMENT


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<InterfaceRepo>(sp => new SqlRepository(connectionString, sp.GetRequiredService<ILogger<SqlRepository>>()));


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

