using CookingHut.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingHut.Infra.Data.Repositories.Interfaces
{
    public interface IRecipeIngredientRepository
    {
        Task<List<RecipeIngredient>> GetAll();

        Task<List<RecipeIngredient>> GetByRecipeId(int recipeId);

        Task<RecipeIngredient> GetById(int id);

        RecipeIngredient Add(RecipeIngredient recipeIngredient);

        RecipeIngredient Update(RecipeIngredient recipeIngredient);

        void Delete(RecipeIngredient recipeIngredient);
    }
}