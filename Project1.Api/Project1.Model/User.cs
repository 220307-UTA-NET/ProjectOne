using Microsoft.AspNetCore.Mvc;

namespace Project1.Model
{
    public class User
    {
        public int bankUserId { get; set; }
        public string bankUserFirstName { get; set; }
        public string bankUserLastName { get; set; }
        public string bankUserUsername { get; set; }
        public string bankUserPassword { get; set; }
        
        // public Role bankRole { get; set; }

        public User() { }
        public User(int bankUserId, string bankUserFirstName, string bankUserLastName, string bankUserUsername,string bankUserPassword)
        {
            this.bankUserId = bankUserId;
            this.bankUserFirstName = bankUserFirstName;
            this.bankUserLastName = bankUserLastName;
            this.bankUserUsername = bankUserUsername;
            this.bankUserPassword = bankUserPassword;
            
        }

        public string GetbankUserFirstName()
        { return this.bankUserFirstName; }

        public string GetbankUserLastName()
        { return this.bankUserLastName; }
        public  string GetbankUserUsername()
        { return this.bankUserUsername; }
        public string GetbankUserPassword()
        { return this.bankUserPassword; }

    }
}