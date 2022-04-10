using Recipe.Logic;

namespace Recipe.DataInfrastructure
{
    public interface IRepository
    {
        IEnumerable<User> ListOfUsers();
        //string ListOfUsernames();
        //public IEnumerable<string> ListOfUsernames();

        //IEnumerable<Recipes> Recipes();
        //User CreateNewUserAcct(string username, string password, string firstName, string lastName);
        //User UpdateUserAcct(string? password); // maybe
        //int CalculateAvgRating(double rating); // look over
        //RecipeClass GetAllRecipeNames();
    }
}
