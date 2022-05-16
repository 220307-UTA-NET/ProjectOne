namespace LibraryApp.UI.DTOs
{
    //defines properties of books data transfer objects
    public class BooksDTO
    {
        public int bookID { get; set; }
        public string title { get; set; }
        public string author { get; set; } 
        public decimal price { get; set; }
        public int inOut { get; set; }
    }
}
