namespace CookingHut.Services.Mapping.Dtos
{
    public class UserFavouriteRecipeDto
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }

        public RecipeDto Recipe { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
    }
}