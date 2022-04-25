namespace RecipeBookApp.UI.DTOs
{
    [Serializable]
    public class IngredientDTO
    {
        public string? RecipeName { get; set; }
        public decimal IngredientQuantity { get; set; }
        public string? UnitOfMeasure { get; set; }
        public string? IngredientName { get; set; }

        public IngredientDTO(string RecipeName, decimal IngredientQuantity, string UnitOfMeasure, string IngredientName)
        {
            this.RecipeName = RecipeName;
            this.IngredientQuantity = IngredientQuantity;
            this.UnitOfMeasure = UnitOfMeasure;
            this.IngredientName = IngredientName;
        }
    }
}
