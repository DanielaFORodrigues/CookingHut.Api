using CookingHut.Domain.Entities;
using CookingHut.Infra.Data.Context;
using CookingHut.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingHut.Infra.Data.Repositories.Implementations
{
    public class RecipeIngredientRepository : IRecipeIngredientRepository
    {
        protected CookingHutDBContext _cookingHutDBContext;
        protected DbSet<RecipeIngredient> _dbSet;

        public RecipeIngredientRepository(CookingHutDBContext cookingHutDBContext)
        {
            _cookingHutDBContext = cookingHutDBContext;
            _dbSet = _cookingHutDBContext.Set<RecipeIngredient>();
        }

        public async Task<List<RecipeIngredient>> GetAll()
        {
            return _dbSet
                .Include(recipe => recipe.Ingredient)
                .ToList();
        }

        public async Task<RecipeIngredient> GetByRecipeId(int recipeId)
        {
            return _dbSet
                .Include(recipeIngredient => recipeIngredient.Ingredient)
                .FirstOrDefault(recipeIngredient => recipeIngredient.RecipeId == recipeId);
        }

        public RecipeIngredient Add(RecipeIngredient recipeIngredient)
        {
            _dbSet.Add(recipeIngredient);
            return recipeIngredient;
        }

        public RecipeIngredient Update(RecipeIngredient recipeIngredient)
        {
            _dbSet.Update(recipeIngredient);
            return recipeIngredient;
        }

        public void Delete(RecipeIngredient recipeIngredient)
        {
            _dbSet.Remove(recipeIngredient);
        }
    }
}