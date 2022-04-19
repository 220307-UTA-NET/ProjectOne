using EmployeeApp.DataLogic;


// WebApp Builder
var builder = WebApplication.CreateBuilder(args);

// Connection String
string connectionString = builder.Configuration["ConnectionString"];
//string connectionString = builder.Configuration.GetConnectionString("RPS-DB-Connection");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRepository>(sp => new SQLRepository(connectionString, sp.GetRequiredService<ILogger<SQLRepository>>()));

// Build WebApp
var app = builder.Build();

// Utilize Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();  // Add middlewares to redicrect HTTP Reequests to HTTPS
app.UseAuthorization();     //
app.MapControllers();       // Add endpoints for controller actions
app.Run();
