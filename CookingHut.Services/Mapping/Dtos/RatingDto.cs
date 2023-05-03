using CookingHut.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingHut.Services.Mapping.Dtos
{
    public class RatingDto

    {
        public int Id { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}