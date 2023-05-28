using CookingHut.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingHut.Infra.Data.Repositories.Interfaces
{
    public interface IRecipeCommentsRepository
    {
        Task<List<RecipeComment>> GetAll();

        Task<List<RecipeComment>> GetByRecipeId(int recipeId);

        Task<RecipeComment> GetById(int id);

        RecipeComment Add(RecipeComment rating);

        RecipeComment Update(RecipeComment rating);

        void Delete(RecipeComment rating);
    }
}