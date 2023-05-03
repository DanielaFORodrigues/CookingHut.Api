using CookingHut.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingHut.Infra.Data.Repositories.Interfaces
{
    public interface IIngredientRepository
    {
        Task<List<Ingredient>> GetAll();

        Task<Ingredient> GetById(int id);

        Ingredient Add(Ingredient ingredient);

        Ingredient Update(Ingredient ingredient);

        void Delete(Ingredient ingredient);
    }
}