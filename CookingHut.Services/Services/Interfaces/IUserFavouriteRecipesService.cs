using CookingHut.Services.Mapping.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingHut.Services.Services.Interfaces
{
    public interface IUserFavouriteRecipesService
    {
        Task<List<UserFavouriteRecipeDto>> GetAll();

        Task<UserFavouriteRecipeDto> GetById(int recipeId, int userId);

        Task<UserFavouriteRecipeDto> Save(UserFavouriteRecipeDto userFavouriteRecipeDto);

        Task Delete(int recipeId, int userId);
    }
}