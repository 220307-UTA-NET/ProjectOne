using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeBookApp.BusinessLogic;


namespace RecipeBookApp.DataLogic
{
    public interface IRepository
    {
        Task<IEnumerable<User>> ListOfUsers();
        Task<ContentResult> CreateNewUser(string username, string password, string firstName, string lastName);

    }
        
