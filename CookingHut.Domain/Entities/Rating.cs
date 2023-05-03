using System.Collections.Generic;

namespace CookingHut.Domain.Entities
{
    public class Rating
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public double RatingValue { get; set; }
    }
}