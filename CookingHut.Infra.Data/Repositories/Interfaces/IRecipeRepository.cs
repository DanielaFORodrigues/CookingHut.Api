using CookingHut.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingHut.Infra.Data.Repositories.Interfaces
{
    public interface IRecipeRepository

    {
        Task<List<Recipe>> GetAll(string type, int id);

        Task<Recipe> GetById(int id);

        Recipe Add(Recipe recipe);

        Recipe Update(Recipe recipe);

        void Delete(Recipe recipe);
    }
}