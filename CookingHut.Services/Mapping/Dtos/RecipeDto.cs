using CookingHut.Domain.Entities;
using CookingHut.Domain.Enums;
using System;
using System.Collections.Generic;

namespace CookingHut.Services.Mapping.Dtos
{
    public class RecipeDto

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string ExecutionTime { get; set; }
        public DifficultyLevel Difficulty { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreationDate { get; set; }
        public List<RecipeIngredientDto> RecipeIngredients { get; set; }
    }
}