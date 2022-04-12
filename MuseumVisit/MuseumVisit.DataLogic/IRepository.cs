using MuseumVisit.BusinessLogic;

namespace MuseumVisit.DataLogic;
public interface IRepository
{
    Task<IEnumerable<Person>> GetAllPersons();
    Task<IEnumerable<Person>> GetPerson(string FirstName, string LastName);
}

