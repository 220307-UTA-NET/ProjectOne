using Database;
using Logic;

var builder = WebApplication.CreateBuilder(args);

//Connection string
//Argument, Hardcoded, file, user Secrets, environemnt variable
string connectionString = builder.Configuration["connectionString"];
//string connectionString = builder.Configuration.GetConnectionString("ProjOneConnection");

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

//app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
