using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using MuseumVisit.BusinessLogic;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using MuseumVisit.DataLogic;

namespace MuseumVisit.Controllers;

[ApiController]
[Route("[controller]")]

public class PersonController : ControllerBase
{
    private readonly IRepository _repository;
    private readonly ILogger<PersonController> _logger;

    // Constructors
    public PersonController(IRepository repository, ILogger<PersonController> logger)
    {
        this._repository = repository;
        this._logger = logger;
    }

    [HttpGet]

    public async Task<ContentResult> GetPerson(string FirstName, string LastName)
    {
        IEnumerable<Person> persons;
        try
        {
            persons = await _repository.GetPerson(FirstName, LastName);
        }
        catch (SqlException ex)
        {
            _logger.LogError(ex, "SQL error while getting person named {FirstName}, {LastName}", FirstName, LastName);
            return new ContentResult()
            {
                StatusCode = 500,
               
            };
        }
        string json = JsonSerializer.Serialize(persons);
        return new ContentResult()
        {
            StatusCode = 200,
            ContentType = "application/json",
            Content = json
        };
    }

    [HttpGet("/lee")]

    public async Task<ActionResult<IEnumerable<Person>>> GetAllPersons()
    {
        IEnumerable<Person> persons;
        try
        {
            persons = await _repository.GetAllPersons();
        }
        catch (SqlException ex)
        {
            _logger.LogError(ex, "SQL error while getting persons.");
            return StatusCode(500);
        }
        return persons.ToList();
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreatePerson(Person person)
    {
        int idnumber;
        try
        {
            _logger.LogInformation("Create Person Called");
            idnumber = await _repository.CreatePerson(person);
        }
        catch(SqlException ex)
        {
            _logger.LogError(ex, "SQL error while creating Person.");
            return StatusCode(500);
        }
        return idnumber;
            
    }

    [HttpDelete]
    public async Task DeletePerson(int Id)
    {
        try
        {
            await _repository.DeletePerson(Id);
            _logger.LogInformation("Delete Person Called");
        }
        catch(SqlException ex)
        {
            _logger.LogError(ex, "SQL error while deleting Person.");
            StatusCode(500);
        }
    }
}

