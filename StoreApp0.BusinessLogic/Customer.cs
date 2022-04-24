

namespace StoreApp0.BusinessLogic
{
	public class Customer
	{
		public int CustomerId { get; set; }
		public String? FirstName { get; set; }
		public String? LastName { get; set; }

		public Customer(int id, String firstName, String lastName)
		{
			this.CustomerId = id;
			this.FirstName = firstName;
			this.LastName = lastName;
		}

		public Customer()
        {

        }
        //public static Microsoft.AspNetCore.Mvc.ActionResult<IEnumerable<Customer>> ToList()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

