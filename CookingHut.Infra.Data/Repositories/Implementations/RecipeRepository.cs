using CookingHut.Domain.Entities;
using CookingHut.Domain.Enums;
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

        public async Task<List<Recipe>> GetAll(string type, int id, string searchText)
        {
            if (type == "search" && string.IsNullOrEmpty(searchText))
            {
                type = string.Empty;
            }

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

                case "search":
                    return _dbSet
                        .Include(recipe => recipe.Category)
                        .Include(recipe => recipe.RecipeIngredients)
                        .Include(recipe => recipe.User)
                        .AsEnumerable()
                        .Where(recipe => recipe.IsApproved)
                        .Where(recipe => FilterRecipe(recipe, searchText))
                        .ToList();

                default:
                    return _dbSet
                        .Include(recipe => recipe.Category)
                        .Include(recipe => recipe.User)
                        .ToList();
            }
        }

        private bool FilterRecipe(Recipe recipe, string searchText)
        {
            var words = searchText.ToLowerInvariant().Split(" ");

            foreach (var word in words)
            {
                if (recipe.Category.Name.ToLowerInvariant().Contains(word)
                    //|| recipe.RecipeIngredients.Any(ing => ing.Ingredient.Name.ToLowerInvariant().Contains(word))
                    || recipe.Name.ToLowerInvariant().Contains(word)
                    || MatchDifficultyLevelWord(recipe.Difficulty, word))
                {
                    return true;
                }
            }

            return false;
        }

        private bool MatchDifficultyLevelWord(DifficultyLevel difficultyLevel, string word)
        {
            if (difficultyLevel == DifficultyLevel.VeryEasy || difficultyLevel == DifficultyLevel.Easy)
            {
                if (word.Contains("facil") || word.Contains("fácil"))
                {
                    return true;
                }
            }

            if (difficultyLevel == DifficultyLevel.Hard || difficultyLevel == DifficultyLevel.VeryHard)
            {
                if (word.Contains("dificil") || word.Contains("difícil"))
                {
                    return true;
                }
            }

            if (difficultyLevel == DifficultyLevel.Medium)
            {
                if (word.Contains("médio") || word.Contains("medio") || word.Contains("intermedio") || word.Contains("intermédio"))
                {
                    return true;
                }
            }

            return false;
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