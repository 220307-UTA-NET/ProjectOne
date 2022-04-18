using MuseumVisit.BusinessLogic;

namespace MuseumVisit.DataLogic;
public interface IRepository
{
    Task<IEnumerable<Person>> GetAllPersons();
    Task<IEnumerable<Person>> GetPerson(string FirstName, string LastName);
    Task<int> CreatePerson(Person person);
    Task DeletePerson(int Id);
}

