using CookingHut.Domain.Enums;
using System;
using System.Collections.Generic;

namespace CookingHut.Domain.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime ExecutionTime { get; set; }
        public DifficultyLevel Difficulty { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; set; }
        public List<Rating> Ratings { get; set; }
        public string User { get; set; }
        public DateTime CreationDate { get; set; }
    }
}