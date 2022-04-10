using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Logic
{
    public class User
    {
        // Fields
        protected string Username;
        protected string UserPassword;
        protected string FirstName;
        protected string LastName;


        // Constructor
        public User() { }
        public User(string username, string password, string firstName, string lastName)
        {
            this.Username = username;
            this.UserPassword = password;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        // Methods

        // Getters
        public string GetUserName()
        {return this.Username;}
        public string GetPassword()
        {return this.UserPassword;}
        public string GetFirstName()
        { return this.FirstName;}
        public string GetLastName()
        {return this.LastName;}


        // Setters
        public void SetUserName()
        { this.Username = Username;}
        public void SetPassword()
        { this.UserPassword = UserPassword;}
        public void SetFirstName()
        { this.FirstName = FirstName; }
        public void SetLastName()
        { this.LastName = LastName; }


        /*        public string CreateUser()
                {
                    StringBuilder sb = new StringBuilder();

                }
        */
    }
}