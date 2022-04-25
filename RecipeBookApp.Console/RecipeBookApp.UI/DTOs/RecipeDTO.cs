
namespace RecipeBookApp.UI.DTOs
{
    [Serializable]
    public class RecipeDTO
    {
        public string? RecipeName { get; set; }
        public decimal Rating { get; set; }


        public RecipeDTO(string RecipeName, decimal Rating)
        {
            this.RecipeName = RecipeName;
            this.Rating = Rating;
        }
    }
}
