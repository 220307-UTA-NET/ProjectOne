using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.DataInfrastructure;
using Recipe.Logic;

namespace Recipe.App
{
    public class RecipeInfo
    {
        // Fields
        IRepository repo;

        // Constructor
        public RecipeInfo(IRepository repo)
        { this.repo = repo; }


        // Methods
        public string ListAllUserNames()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("These are all the usernames:");
            IEnumerable<User> listObj = repo.ListOfUsers();
            foreach (User userList in listObj)
            {
                sb.AppendLine(userList.GetUserName());
            }
            return sb.ToString();
        }

        public string ListAllPasswords()  // Don't actually need this method, but will need way to check password against username
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("These are all the usernames:");
            IEnumerable<User> listObj = repo.ListOfUsers();
            foreach (User userList in listObj)
            {
                sb.AppendLine(userList.GetPassword());
            }
            return sb.ToString();
        } 



    }
}
