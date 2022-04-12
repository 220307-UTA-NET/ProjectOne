namespace Museum.Logic;
public class Person
{
    int Id { get; set; }

    string FirstName { get; set; }

    string LastName { get; set; }

    public Person(int Id, string FirstName, string LastName)
    {
        this.Id = Id;
        this.FirstName = FirstName;
        this.LastName = LastName;
    }

}

