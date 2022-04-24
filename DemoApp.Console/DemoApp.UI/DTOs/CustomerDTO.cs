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


        //cunstructor

        public CustomerDTO(int custId, int IsVerified, string custFirstName, string custLastName, string custAddress, string dob)
        {
            this.custId = custId;
            this.IsVerified = IsVerified;
            this.custFirstName = custFirstName;
            this.custLastName = custLastName;
            this.custAddress = custAddress;
            this.dob = dob;
        }


    }

}

