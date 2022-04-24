namespace EmployeeApp.UI.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int BranchId { get; set; }
        public string? Department { get; set; }
        public string? Title { get; set; }
        public DateTime HiredDate { get; set; }
    }
}
