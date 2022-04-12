using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using MuseumVisit.BusinessLogic;
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

    public async Task<ActionResult<IEnumerable<Person>>> GetDeviceByNameAsync(string id)
    {
        IEnumerable<Person> persons;
        try
        {
            persons = await _repository.GetPerson(id);
        }
        catch (SqlException ex)
        {
            _logger.LogError(ex, "SQL error while getting devices named {id}.", id);
            return StatusCode(500);
        }
        return persons.ToList();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Person>>> GetAllPersons()
    {
        IEnumerable<Person> persons;
        try
        {
            persons = await _repository.GetAllPersons();
        }
        catch (SqlException ex)
        {
            _logger.LogError(ex, "SQL error while getting devices.");
            return StatusCode(500);
        }
        return persons.ToList();
    }
}

