namespace EmployeeApp.BusinessLogic
{
    public class Employee
    {
        // Fields
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int BranchId { get; set; }
        public string? Department { get; set; }
        public string? Title { get; set; }
        public DateTime HiredDate { get; set; }

        // Constructors
        public Employee() { }   // Defualt constructor

        // Overloaded constructors
        public Employee(int Id, string FirstName, string LastName, DateTime BirthDate, int BranchId, string Department, string Title, DateTime HiredDate)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BirthDate = BirthDate;
            this.BranchId = BranchId;
            this.Department = Department;
            this.Title = Title;
            this.HiredDate = HiredDate;
        }

        // Methods
    }
}