using CookingHut.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingHut.Infra.Data.Repositories.Interfaces
{
    public interface IUserFavouriteRecipesRepository
    {
        Task<List<UserFavouriteRecipe>> GetAll();

        Task<UserFavouriteRecipe> GetById(int recipeId, int userId);

        UserFavouriteRecipe Add(UserFavouriteRecipe userFavouriteRecipe);

        void Delete(UserFavouriteRecipe userFavouriteRecipe);
    }
}