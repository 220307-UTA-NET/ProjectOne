namespace LibraryApp.UI.DTOs
{
    internal class RentalsDTO
    {
        public int rentalID { get; set; }
        public int memberID { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public int bookID { get; set; }
        public string title { get; set; }
        public DateTime OutDate { get; }
        public DateTime InDate { get; set; }
    }
}
