using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
namespace MuseumVisit.BusinessLogic
{
	public class PersonContext : DbContext
	{
		public PersonContext(DbContextOptions<PersonContext> options)
		  : base(options)
		{
		}

		public DbSet<Person> TodoItems { get; set; } = null!;

		public PersonContext()
		{
		}
	}
}

