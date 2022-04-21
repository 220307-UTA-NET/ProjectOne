namespace RecipeBookApp.UI.DTOs
{
    [Serializable]
    public class UserDTO
    {
        public string? Username { get; set; }
        public string? UserPassword { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public UserDTO(string Username, string UserPassword, string FirstName, string LastName)
        {
            this.Username = Username;
            this.UserPassword = UserPassword; 
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
       
    }
}
