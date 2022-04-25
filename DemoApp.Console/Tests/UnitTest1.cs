using DemoApp.UI;
using DemoApp.DTOs;
using Xunit;
using System.Net.Http;

namespace Tests;

public class UnitTest1
{
	private readonly CustomerDTO customer = new CustomerDTO(1, 2, "Test", "West", "123abc street", "1985-01-23");
    
	[Fact]
	public void Fact1()
	{
		//ARRANGE
		string expectedFirstName = "Sahar";
		string expectedLastName = "Samani";


		//ACT
		CustomerDTO customer = new CustomerDTO(9, 1, "Sahar", "Samani", "12 W. MAANN st.", "1990-08-08");


		//ASSERT
		Assert.Equal(expectedFirstName, customer.custFirstName);
		Assert.Equal(9, customer.custId);


	}

	[Fact]
	public void Fact2()
    {
		//ASSERT
		Assert.IsType<HttpClient>(IO.httpClient);
    }


	[Fact]
	public void Fact3()
    {
		//ASSERRS
		Assert.StartsWith(customer.custFirstName, "Test");
    }

	
}
