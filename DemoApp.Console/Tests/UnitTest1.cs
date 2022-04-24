using DemoApp.UI;
using DemoApp.DTOs;
using Xunit;

namespace Tests;

public class UnitTest1
{
    
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

	
}
