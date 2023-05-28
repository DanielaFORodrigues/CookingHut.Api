using CookingHut.Domain.Entities;
using CookingHut.Infra.Data.Context;
using CookingHut.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingHut.Infra.Data.Repositories.Implementations
{
    public class UserFavouriteRecipesRepository : IUserFavouriteRecipesRepository
    {
        protected CookingHutDBContext _cookingHutDBContext;
        protected DbSet<UserFavouriteRecipe> _dbSet;

        public UserFavouriteRecipesRepository(CookingHutDBContext cookingHutDBContext)
        {
            _cookingHutDBContext = cookingHutDBContext;
            _dbSet = _cookingHutDBContext.Set<UserFavouriteRecipe>();
        }

        public async Task<List<UserFavouriteRecipe>> GetAll()
        {
            return _dbSet
                .Include(userFavouriteRecipe => userFavouriteRecipe.Recipe)
                .Include(userFavouriteRecipe => userFavouriteRecipe.User)
                .ToList();
        }

        public async Task<UserFavouriteRecipe> GetById(int recipeId, int userId)
        {
            return _dbSet
                .Include(userFavouriteRecipe => userFavouriteRecipe.Recipe)
                .Include(userFavouriteRecipe => userFavouriteRecipe.User)
                .FirstOrDefault(userFavouriteRecipe => userFavouriteRecipe.RecipeId == recipeId && userFavouriteRecipe.UserId == userId);
        }

        public UserFavouriteRecipe Add(UserFavouriteRecipe userFavouriteRecipe)
        {
            _dbSet.Add(userFavouriteRecipe);
            return userFavouriteRecipe;
        }

        public void Delete(UserFavouriteRecipe userFavouriteRecipe)
        {
            _dbSet.Remove(userFavouriteRecipe);
        }
    }
}