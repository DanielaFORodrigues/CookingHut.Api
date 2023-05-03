using CookingHut.Domain.Entities;
using CookingHut.Infra.Data.Context;
using CookingHut.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingHut.Infra.Data.Repositories.Implementations
{
    public class RatingRepository : IRatingRepository
    {
        protected CookingHutDBContext _cookingHutDBContext;
        protected DbSet<Rating> _dbSet;

        public RatingRepository(CookingHutDBContext cookingHutDBContext)
        {
            _cookingHutDBContext = cookingHutDBContext;
            _dbSet = _cookingHutDBContext.Set<Rating>();
        }

        public async Task<List<Rating>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Rating> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Rating Add(Rating rating)
        {
            _dbSet.Add(rating);
            return rating;
        }

        public Rating Update(Rating rating)
        {
            _dbSet.Update(rating);
            return rating;
        }

        public void Delete(Rating rating)
        {
            _dbSet.Remove(rating);
        }
    }
}