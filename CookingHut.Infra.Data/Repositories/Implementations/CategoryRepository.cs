using CookingHut.Domain.Entities;
using CookingHut.Infra.Data.Context;
using CookingHut.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingHut.Infra.Data.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        protected CookingHutDBContext _cookingHutDBContext;
        protected DbSet<Category> _dbSet;

        public CategoryRepository(CookingHutDBContext cookingHutDBContext)
        {
            _cookingHutDBContext = cookingHutDBContext;
            _dbSet = _cookingHutDBContext.Set<Category>();
        }

        public Category Add(Category category)
        {
            _dbSet.Add(category);
            return category;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Category Update(Category category)
        {
            _dbSet.Update(category);
            return category;
        }

        public void Delete(Category category)
        {
            _dbSet.Remove(category);
        }
    }
}