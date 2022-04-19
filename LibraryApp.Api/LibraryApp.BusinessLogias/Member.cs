namespace LibraryApp.BusinessLogias
{
    public class Member
    {
        //Fields
        public int MemberID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }

        //Constructors
        public Member() { }
        public Member (int memberID, string fName, string lName, string phone)
        {
            this.MemberID = memberID;
            this.FName = fName;
            this.LName = lName;
            this.Phone = phone;
        }

        //Methods
    }
}