using CookingHut.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingHut.Infra.Data.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();

        Task<Category> GetById(int id);

        Category Add(Category category);

        Category Update(Category category);

        void Delete(Category category);
    }
}