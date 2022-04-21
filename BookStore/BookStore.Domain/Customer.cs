using System.Text.Json.Serialization;

namespace BookStore.Domain
{
    public class Customer
    {
        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        [JsonConstructor]
        public Customer(string firstName, string lastName, int defaultLocationId)
        {
            FirstName = firstName;
            LastName = lastName;
            DefaultLocationID = defaultLocationId;
        }

        public Customer(int id, string firstName, string lastName, int defaultLocationId)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            DefaultLocationID = defaultLocationId;
        }

        /// <summary>
        /// Identifier for the Customer.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// First name of the Customer.
        /// </summary>
        public string FirstName {get; set;}

        /// <summary>
        /// Last name of the Customer.
        /// </summary>
        public string LastName {get; set;}

        /// <summary>
        /// The ID for the Location that the Customer would order from by default.
        /// </summary>
        public int DefaultLocationID {get; set;}
    }
}
