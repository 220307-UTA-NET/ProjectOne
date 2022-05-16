namespace LibraryApp.UI.DTOs
{
    //defines properties of rentals data transfer objects
    public class RentalsDTO
    {
        public int rentalID { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public int memberID { get; set; }
        public int bookID { get; set; }
        public string title { get; set; }
        public int inOut { get; set; }
    }
}
