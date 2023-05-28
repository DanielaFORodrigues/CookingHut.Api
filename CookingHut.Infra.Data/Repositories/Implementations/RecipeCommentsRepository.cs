using CookingHut.Domain.Entities;
using CookingHut.Infra.Data.Context;
using CookingHut.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingHut.Infra.Data.Repositories.Implementations
{
    public class RecipeCommentsRepository : IRecipeCommentsRepository
    {
        protected CookingHutDBContext _cookingHutDBContext;
        protected DbSet<RecipeComment> _dbSet;

        public RecipeCommentsRepository(CookingHutDBContext cookingHutDBContext)
        {
            _cookingHutDBContext = cookingHutDBContext;
            _dbSet = _cookingHutDBContext.Set<RecipeComment>();
        }

        public async Task<List<RecipeComment>> GetAll()
        {
            return _dbSet
                .Include(recipeComment => recipeComment.Recipe)
                .Include(recipeComment => recipeComment.User)
                .ToList();
        }

        public async Task<List<RecipeComment>> GetByRecipeId(int recipeId)
        {
            return _dbSet
                .Include(recipeComment => recipeComment.Recipe)
                .Include(recipeComment => recipeComment.User)
                .Where(recipeComment => recipeComment.RecipeId == recipeId)
                .ToList();
        }

        public async Task<RecipeComment> GetById(int id)
        {
            return _dbSet
                .Include(recipeComment => recipeComment.Recipe)
                .Include(recipeComment => recipeComment.User)
                .FirstOrDefault(recipeComment => recipeComment.Id == id);
        }

        public RecipeComment Add(RecipeComment recipeComment)
        {
            _dbSet.Add(recipeComment);
            return recipeComment;
        }

        public RecipeComment Update(RecipeComment recipeComment)
        {
            _dbSet.Update(recipeComment);
            return recipeComment;
        }

        public void Delete(RecipeComment recipeComment)
        {
            _dbSet.Remove(recipeComment);
        }
    }
}