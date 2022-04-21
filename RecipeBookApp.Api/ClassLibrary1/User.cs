
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookApp.BusinessLogic
{
    public class User
    {
        // Fields
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string username { get; set; }
        //public string password { get; set; }

        //protected string Username;
        //protected string UserPassword;
        //protected string FirstName;
        //protected string LastName;

        // Constructor
        public User() { }
        public User(string username, string password, string firstName, string lastName)
        {
            this.Username = username;
            this.UserPassword = password;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
   */
    }
}