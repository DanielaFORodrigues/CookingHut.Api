using CookingHut.Services.Mapping.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingHut.Services.Services.Interfaces
{
    public interface IRecipeIngredientService
    {
        Task<List<RecipeIngredientDto>> GetAll();

        Task<RecipeIngredientDto> GetById(int id);

        Task<RecipeIngredientDto> Save(RecipeIngredientDto recipeIngredientDto);

        Task Delete(RecipeIngredientDto recipeIngredientDto);
    }
}