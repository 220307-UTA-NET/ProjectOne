namespace DemoApp.BusinessLogic
{
    public class Employee
    {

        public int empId { get; set; }
        public string empFirstName { get; set; }
        public string empLastName { get; set; }


        public Employee(int id, string empFirstNamee, string empLastName)
        {
            this.empId = empId;
            this.empFirstName = empFirstName;
            this.empLastName = empLastName;

        }

        public int getEmployeeId()
        {
            return this.empId;
        }

        public int setEmployeeId(int empId)
        {
            return this.empId = empId;
        }


        public string getEmployeeFirstName(string empFirstName)
        {
            return this.empFirstName;
        }

        public string setEmployeeLastName(string empLastName)
        {
            return this.empLastName = empLastName;
        }




    }
}