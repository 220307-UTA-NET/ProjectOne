using P_One.Database;
using P_One.Logic;

var builder = WebApplication.CreateBuilder(args);

//Connection for localhost testing
//string connectionString = builder.Configuration["connectionString"];
//Connection for Deployment to Azure
string connectionString = builder.Configuration.GetConnectionString("ProjOneConnection");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRepo>(sp => new SqlRepo(connectionString, sp.GetRequiredService<ILogger<SqlRepo>>()));

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
