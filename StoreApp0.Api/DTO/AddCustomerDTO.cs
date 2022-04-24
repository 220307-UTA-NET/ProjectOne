using System;
using System.ComponentModel.DataAnnotations;

namespace StoreApp0.Api.DTO
{
	public class AddCustomerDTO
	{
		
			[Required]
			public string? FirstName { get; set; }

			[Required]
			public string? LastName { get; set; }
	
	}
}

