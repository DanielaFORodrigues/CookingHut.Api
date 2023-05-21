using CookingHut.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingHut.Services.Mapping.Dtos
{
    public class IngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; set; }
    }
}