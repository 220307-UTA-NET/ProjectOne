using System;
namespace MuseumConsole.DTOs
{
	public class PersonDTO
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string Lastname { get; set; }
		public int Salary { get; set; }
		public int VisitList { get; set; }
		public PersonDTO()
		{
		}
	}
}

