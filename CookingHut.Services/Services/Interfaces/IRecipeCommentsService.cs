using CookingHut.Services.Mapping.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingHut.Services.Services.Interfaces
{
    public interface IRecipeCommentsService
    {
        Task<List<RecipeCommentDto>> GetAll();

        Task<List<RecipeCommentDto>> GetByRecipeId(int recipeId);

        Task<RecipeCommentDto> GetById(int id);

        Task<RecipeCommentDto> Save(RecipeCommentDto recipeCommentsDto);

        Task Delete(int id);
    }
}