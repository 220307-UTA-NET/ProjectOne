using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MuseumVisit.BusinessLogic;
using MuseumVisit.DataLogic;

using System.Linq;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Museum.Test;

public class UnitTest1
{
    [Fact]
    public void CreatePersonObject_ValidPerson()
    {
        //Arrange

        Person test = new Person(33, "Ike", "Mike", 58575, 434);

        //Act

        string actual = test.FirstName;

        //Assert

        string expected = "Ike";

        Assert.Equal(expected, actual);

    }

    [Fact]
    public async Task MuseumVisit_GetPerson_ValidPerson()
    {
        Mock<IRepository> mockRepo = new();
        Person test = new Person(33, "Ike", "Mike", 58575, 434);
        IEnumerable<Person> Donkey = new Person[] {test};

        string json = JsonSerializer.Serialize(Donkey);
        Mock<ILogger<MuseumVisit.Controllers.PersonController>> mocklog = new();

        mockRepo.Setup(x => x.GetPerson("Ike", "Mike")).ReturnsAsync(Donkey);
        var superlist = new MuseumVisit.Controllers.PersonController(mockRepo.Object, mocklog.Object);

        //act
        var test1 = await superlist.GetPerson("Ike", "Mike");

        //assert

        Assert.Equal(json, test1.Content);

       
    }
    
}
