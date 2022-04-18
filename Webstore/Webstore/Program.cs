using irepository;

var builder = WebApplication.CreateBuilder(args);
string connectionstring = builder.Configuration.GetConnectionString("connectionstring");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<Irepository>(sp => new sqldata(connectionstring, sp.GetRequiredService<ILogger<sqldata>>()));
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.MapGet("/", () => "Hello World!, this is the beginning ");

app.Run();
