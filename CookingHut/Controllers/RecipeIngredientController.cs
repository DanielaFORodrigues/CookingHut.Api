using CookingHut.Services.Mapping.Dtos;
using CookingHut.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingHut.Controllers
{
    [Route("CookingHut/[controller]")]
    [ApiController]
    public class RecipeIngredientController : ControllerBase
    {
        private readonly IRecipeIngredientService _service;

        public RecipeIngredientController(IRecipeIngredientService recipeIngredientService)
        {
            _service = recipeIngredientService;
        }

        [HttpGet]
        public List<RecipeIngredientDto> GetAll()
        {
            return _service.GetAll().Result;
        }

        [HttpGet("{recipeId}")]
        public List<RecipeIngredientDto> GetById(int recipeId)
        {
            return _service.GetByRecipeId(recipeId).Result;
        }

        [HttpPost]
        public RecipeIngredientDto Save(RecipeIngredientDto recipeIngredientDto)
        {
            return _service.Save(recipeIngredientDto).Result;
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _service.Delete(id);
        }
    }
}