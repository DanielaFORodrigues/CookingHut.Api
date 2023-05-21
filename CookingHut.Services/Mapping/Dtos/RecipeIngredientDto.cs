using CookingHut.Domain.Entities;
using CookingHut.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingHut.Services.Mapping.Dtos
{
    public class RecipeIngredientDto

    {
        public int Id { get; set; }

        public int RecipeId { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        public int Quantity { get; set; }
        public UnitOfMeasurement Unit { get; set; }
    }
}