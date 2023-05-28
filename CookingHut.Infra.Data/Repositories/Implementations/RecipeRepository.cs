using CookingHut.Domain.Entities;
using CookingHut.Infra.Data.Context;
using CookingHut.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingHut.Infra.Data.Repositories.Implementations
{
    public class RecipeRepository : IRecipeRepository
    {
        protected CookingHutDBContext _cookingHutDBContext;
        protected DbSet<Recipe> _dbSet;

        public RecipeRepository(CookingHutDBContext cookingHutDBContext)
        {
            _cookingHutDBContext = cookingHutDBContext;
            _dbSet = _cookingHutDBContext.Set<Recipe>();
        }

        public async Task<List<Recipe>> GetAll(string type, int id)
        {
            switch (type)
            {
                case "approval":
                    return _dbSet
                        .Include(recipe => recipe.Category)
                        .Include(recipe => recipe.User)
                        .Where(recipe => recipe.IsApproved == false)
                        .ToList();

                case "favourites":
                    return _dbSet
                        .Include(recipe => recipe.Category)
                        .Include(recipe => recipe.User)
                        .Include(recipe => recipe.UserFavouriteRecipes)
                        .Where(recipe => recipe.UserFavouriteRecipes.Any(favourite => favourite.UserId == id))
                        .ToList();

                case "owner":
                    return _dbSet
                        .Include(recipe => recipe.Category)
                        .Include(recipe => recipe.User)
                        .Where(recipe => recipe.UserId == id)
                        .ToList();

                case "category":
                    return _dbSet
                        .Include(recipe => recipe.Category)
                        .Include(recipe => recipe.User)
                        .Where(recipe => recipe.CategoryId == id && recipe.IsApproved)
                        .ToList();

                default:
                    return _dbSet
                        .Include(recipe => recipe.Category)
                        .Include(recipe => recipe.User)
                        .ToList();
            }
        }

        public async Task<Recipe> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Recipe Add(Recipe recipe)
        {
            _dbSet.Add(recipe);
            return recipe;
        }

        public Recipe Update(Recipe recipe)
        {
            _dbSet.Update(recipe);
            return recipe;
        }

        public void Delete(Recipe recipe)
        {
            _dbSet.Remove(recipe);
        }
    }
}