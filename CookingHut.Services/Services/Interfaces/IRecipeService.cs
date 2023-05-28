using CookingHut.Services.Mapping.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingHut.Services.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<List<RecipeDto>> GetAll(string type, int id, string searchText);

        Task<RecipeDto> GetById(int id);

        Task<RecipeDto> Save(RecipeDto recipeDto);

        Task Delete(int id);
    }
}