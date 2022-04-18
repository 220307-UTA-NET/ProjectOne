using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.BusinessLogias
{
    public class Book
    {
        //Fields
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool InOut { get; set; }

        //Constructors
        public Book() { }
        public Book(int bookID, string title, string author, bool inOut)
        {
            this.BookID = bookID;
            this.Title = title;
            this.Author = author;
            this.InOut = inOut;
        }
    }

    

}
