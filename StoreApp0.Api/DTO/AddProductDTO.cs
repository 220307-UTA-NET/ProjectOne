using System;
using System.ComponentModel.DataAnnotations;

namespace StoreApp0.Api.DTO
{
	public class AddProductDTO
	{

		[Required]
		public string? ProductName { get; set; }

		[Required]
		public string? ProductCatagory { get; set; }

	}
}
