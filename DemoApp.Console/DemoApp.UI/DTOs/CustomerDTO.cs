using System;
namespace DemoApp.DTOs
{
	public class CustomerDTO
    {
        public int custId { get; set; }
        public int IsVerified { get; set; }
        public string? custFirstName { get; set; }
        public string? custLastName { get; set; }
        public string? custAddress { get; set; }
        public string? dob { get; set; }


    }

}

