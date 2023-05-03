using CookingHut.Services.Mapping.Dtos;
using CookingHut.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public RecipeDto Save(RecipeDto recipeDto)
        {
            return _service.Save(recipeDto).Result;
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