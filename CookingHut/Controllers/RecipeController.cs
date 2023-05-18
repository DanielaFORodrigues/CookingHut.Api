using CookingHut.Services.Mapping.Dtos;
using CookingHut.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingHut.Controllers
{
    [Route("CookingHut/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _service;

        public RecipeController(IRecipeService recipeService)
        {
            _service = recipeService;
        }

        [HttpGet]
        public List<RecipeDto> GetAll()
        {
            return _service.GetAll().Result;
        }

        [HttpGet("{id}")]
        public RecipeDto GetById(int id)
        {
            return _service.GetById(id).Result;
        }

        [HttpPost]
        public async Task<IActionResult> Save(RecipeDto recipeDto)
        {
            recipeDto.CreationDate = System.DateTime.UtcNow;
            var recipe = await _service.Save(recipeDto);

            return Ok(recipe);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            RecipeDto recipe = _service.GetById(id).Result;
            if (recipe != null)
                _service.Delete(recipe);
        }
    }
}