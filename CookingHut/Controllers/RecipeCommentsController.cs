using CookingHut.Domain.Entities;
using CookingHut.Services.Mapping.Dtos;
using CookingHut.Services.Services.Implementations;
using CookingHut.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingHut.Controllers
{
    [Route("CookingHut/[controller]")]
    [ApiController]
    public class RecipeCommentsController

    {
        private readonly IRecipeCommentsService _service;

        public RecipeCommentsController(IRecipeCommentsService recipeCommentsService)
        {
            _service = recipeCommentsService;
        }

        [HttpGet]
        public List<RecipeCommentDto> GetAll()
        {
            return _service.GetAll().Result;
        }

        [HttpGet("{recipeId}")]
        public List<RecipeCommentDto> GetById(int recipeId)
        {
            return _service.GetByRecipeId(recipeId).Result;
        }

        [HttpPost]
        public RecipeCommentDto Save(RecipeCommentDto recipeCommentsDto)
        {
            recipeCommentsDto.DatePost = System.DateTime.UtcNow;
            return _service.Save(recipeCommentsDto).Result;
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _service.Delete(id);
        }
    }
}