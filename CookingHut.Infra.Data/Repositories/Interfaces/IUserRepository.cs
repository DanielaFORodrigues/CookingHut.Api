using CookingHut.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingHut.Infra.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();

        Task<User> GetById(int id);

        User GetLogin(string email, string password);

        User Add(User User);

        User Update(User user);

        void Delete(User user);
    }
}