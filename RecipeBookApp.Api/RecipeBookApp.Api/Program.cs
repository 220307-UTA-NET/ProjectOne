using System.Data.SqlClient;
using RecipeBookApp.DataLogic;
using RecipeBookApp.BusinessLogic;
//using RecipeBookApp.Api.Controllers;


var builder = WebApplication.CreateBuilder(args);

// Connection String:
// Argument, Hardcoded, File, User Secrets, Environmental Variables
//string connectionString = builder.Configuration.GetConnectionString("connectionString");



//Uri uri = new Uri("https://revatureprojectone.azurewebsites.net");
//Uri uri = new Uri("https://localhost:7089");



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// For Deployment
//string connectionString = builder.Configuration.GetConnectionString("RPS-DB-Connection");
//builder.Services.AddSingleton<IRepository>(sp => new SqlRepository(connectionString, sp.GetRequiredService<ILogger<SqlRepository>>()));
//var app = builder.Build();
//builder.Services.AddSingleton<IRepository>(sp => new SqlRepository(SqlConnectionStringBuilder, sp.GetRequiredService<ILogger<SqlRepository>>()));
//Uri uri = new Uri("https://revatureprojectone.azurewebsites.net");


// For Development
Uri uri = new Uri("https://localhost:7089");
string connectionString = File.ReadAllText(@"/Revature/ConnectionStrings/Project0.txt");
//string connectionString = builder.Configuration.GetConnectionString(connectionString);
builder.Services.AddSingleton<IRepository>(sp => new SqlRepository(connectionString, sp.GetRequiredService<ILogger<SqlRepository>>()));
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

//////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////


/*



public async Task<User> CreateNewUser(string username, string password, string firstName, string lastName)
{
    //List<User> returnList = new();

    using SqlConnection connection2 = new(_connectionString);
    await connection2.OpenAsync();

    string cmdTxt =
      @"INSERT INTO Recipes.Users (username, password, FirstName, LastName)  
              VALUES
                (@username, @password, @FirstName, @LastName),";


    using SqlCommand SQLcmd = new SqlCommand(cmdTxt, connection2);

    SQLcmd.Parameters.AddWithValue("@username", username);
    SQLcmd.Parameters.AddWithValue("@password", password);
    SQLcmd.Parameters.AddWithValue("@FirstName", firstName);
    SQLcmd.Parameters.AddWithValue("@LastName", lastName);

    SQLcmd.ExecuteNonQuery();


    cmdTxt = @"SELECT username, password, FirstName, LastName FROM Recipes.Users WHERE username = @username;";

    using SqlCommand SQLcmd2 = new SqlCommand(cmdTxt, connection2);

    SQLcmd2.Parameters.AddWithValue("@username", username);
    SQLcmd2.Parameters.AddWithValue("@password", password);
    SQLcmd2.Parameters.AddWithValue("@FirstName", firstName);
    SQLcmd2.Parameters.AddWithValue("@LastName", lastName);


    using SqlDataReader myReader = SQLcmd2.ExecuteReader();
    //List<string> result = new List<string>();
    User newUserAcct;

    //User newUserAcct;
    while (myReader.Read())
    {
        var uName = myReader.GetString(0);
        var passN = myReader.GetString(1);
        var FName = myReader.GetString(2);
        var LName = myReader.GetString(3);
        return newUserAcct = new User(uName, passN, FName, LName);
        //return returnAcct;
        //result.Add(new(uName, passN, FName, LName));
    }
    //User newUser = CreateNewUser(uName, passN, FName, LName);

    await connection2.CloseAsync();
    //User noUser = new();
    _logger.LogInformation("Executed: Created New User Acct");
    User none = null;
    return none;





*/






//////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////




// CreateNewUserAsync([FromBody] List<User> listOfUser);

//app.UseStaticFiles();

//app.UseRouting();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");


//CreateNewUser()