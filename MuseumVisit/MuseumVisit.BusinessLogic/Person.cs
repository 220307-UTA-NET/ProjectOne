namespace MuseumVisit.BusinessLogic;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Salary { get; set; }
    public int VisitList { get; set; }

    public Person() { }


    public Person(int Id, string FirstName, string LastName, int Salary, int VisitList)
    {
        this.Id = Id;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Salary = Salary;
        this.VisitList = VisitList;
    }
}

