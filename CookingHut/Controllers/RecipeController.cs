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
        public async Task<List<RecipeDto>> GetAllAsync(string type, int id, string searchText)
        {
            return await _service.GetAll(type, id, searchText);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var recipe = await _service.GetById(id);

            if (recipe is null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> Save(RecipeDto recipeDto)
        {
            recipeDto.CreationDate = System.DateTime.UtcNow;
            var recipe = await _service.Save(recipeDto);

            return Ok(recipe);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _service.Delete(id);
        }
    }
}