using CookingHut.Domain.Entities;
using CookingHut.Infra.Data.Context;
using CookingHut.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingHut.Infra.Data.Repositories.Implementations
{
    public class IngredientRepository : IIngredientRepository
    {
        protected CookingHutDBContext _cookingHutDBContext;
        protected DbSet<Ingredient> _dbSet;

        public IngredientRepository(CookingHutDBContext cookingHutDBContext)
        {
            _cookingHutDBContext = cookingHutDBContext;
            _dbSet = _cookingHutDBContext.Set<Ingredient>();
        }

        public Ingredient Add(Ingredient ingredient)
        {
            _dbSet.Add(ingredient);
            return ingredient;
        }

        public async Task<List<Ingredient>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Ingredient> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Ingredient Update(Ingredient ingredient)
        {
            _dbSet.Update(ingredient);
            return ingredient;
        }

        public void Delete(Ingredient ingredient)
        {
            _dbSet.Remove(ingredient);
        }
    }
}