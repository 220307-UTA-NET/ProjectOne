namespace StoreApplication.BusinessLogic
{
    public class Customer
    {
        // Fields
        public string? firstname { get; set; }
        public string? lastname { get; set; }
        public string? phone { get; set; }
        public string? product { get; set; }
        public string? location { get; set; }

        public string? amountspent { get; set; }
        public string? id { get; set; }


        // Constructors
        public Customer() { }

        public Customer(string firstname, string lastname, string phone, string product, string location, string amountspent, string id)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.phone = phone;
            this.product = product;
            this.location = location;
            this.amountspent = amountspent;
            this.id = id;

        }

        // Methods
    }
}