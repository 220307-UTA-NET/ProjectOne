using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using StoreApp0.Api.Controllers;
using StoreApp0.Api.DTO;
using StoreApp0.BusinessLogic;
using StoreApp0.DataLogic;

namespace StoreApp0.Tests.IntegrationTests
{
	[TestClass]
	public class CustomersControllerTests
	{
		private readonly CustomersController _customersController;
		private readonly IRepository _repository = Substitute.For<IRepository>();
		private readonly ILogger<CustomersController> _logger = Substitute.For<ILogger<CustomersController>>();

		public CustomersControllerTests()
		{
			_customersController = new CustomersController(_repository, _logger);
		}

		[TestMethod]

		public async Task ShouldReturnCustomer_WhenValidIdPassed()
		{
			var customer = new Customer()
			{
				CustomerId = 5,
				FirstName = "Test Customer First Name",
				LastName = "Test Customer Last Name"
			};
			_repository.GetCustomerById(Arg.Any<int>()).Returns(Task.FromResult<Customer>(customer));
			var actionResult = await _customersController.GetById(10);
			var response = (ObjectResult)actionResult;

			Assert.AreEqual(response.StatusCode, 200);
			var customerDTO = (CustomerDTO)response.Value;
			Assert.IsNotNull(customerDTO);
			Assert.AreEqual(customerDTO.Id, customer.CustomerId);

		}
		
	}

}

