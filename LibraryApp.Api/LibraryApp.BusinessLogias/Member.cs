namespace LibraryApp.BusinessLogias
{
    public class Member
    {
        //Fields
        public int memberID { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string phone { get; set; }

        //Constructors
        public Member() { }
        public Member (string fName, string lName, string phone)
        {
            this.fName = fName;
            this.lName = lName;
            this.phone = phone;
        }
        public Member(int memberID, string fName, string lName, string phone)
        {
            this.memberID = memberID;
            this.fName = fName;
            this.lName = lName;
            this.phone = phone;
        }

        //Methods
        public string GetFName()
            { return this.fName; }
        public string GetLName()
            { return this.lName; }
        public string GetPhone()
            { return this.phone; }
    }
}