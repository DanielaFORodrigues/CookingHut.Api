using CookingHut.Domain.Entities;
using CookingHut.Infra.Data.Context;
using CookingHut.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingHut.Infra.Data.Repositories.Implementations
{
    public class UserRepository : IUserRepository

    {
        protected CookingHutDBContext _cookingHutDBContext;
        protected DbSet<User> _dbSet;

        public UserRepository(CookingHutDBContext cookingHutDBContext)
        {
            _cookingHutDBContext = cookingHutDBContext;
            _dbSet = _cookingHutDBContext.Set<User>();
        }

        public async Task<List<User>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public User GetLogin(string email, string password)
        {
            return _dbSet.FirstOrDefault(user => user.Email == email && user.Password == password);
        }

        public User Add(User user)
        {
            _dbSet.Add(user);
            return user;
        }

        public User Update(User user)
        {
            _dbSet.Update(user);
            return user;
        }

        public void Delete(User user)
        {
            _dbSet.Remove(user);
        }
    }
}