using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.BusinessLogias
{
    public class Rental
    {
        //Fields
        int rentalID { get; set; }
        int memberID { get; set; }
        //string fName { get; set; }
        //string lName { get; set; }
        int bookID { get; set; }
        //string title { get; set; }
        //int inOut { get; set; }

        //Constructors
        public Rental() { }
        public Rental(int memberID, int bookID)
        {
            this.memberID = memberID;
            this.bookID = bookID;
        }
        public Rental( int memberID, int bookID, int rentalID)
        {
            this.rentalID = rentalID;
            this.memberID = memberID;
            this.bookID = bookID;

        }
        /*public Rental( int rentalID,  string fName, string lName, int memberID, int bookID, string title, int inOut )
        {
            this.rentalID = rentalID;
            this.fName = fName;
            this.lName = lName;
            this.memberID = memberID;
            this.bookID = bookID;
            this.title = title;
            this.inOut = inOut;
        }*/
        //methods
        public int GetRentalID()
            { return this.rentalID; }
        public int GetMemberID()
            { return this.memberID; }
        //public string GetFName()
        //    { return this.fName; }
        //public string GetLName()
        //    { return this.lName; }
        public int GetBookID()
            { return this.bookID; }
        //public string GetTitle()
        //    { return this.title; }
        //public int GetInOut()
        //    { return this.inOut; }

        

        
               
    }
}
