namespace LibraryApp.UI.DTOs
{
    public class BooksDTO
    {
        public int bookID { get; set; }
        public string title { get; set; }
        public string author { get; set; } 
        public int price { get; set; }
        public bool inStock { get; set; }
    }
}
