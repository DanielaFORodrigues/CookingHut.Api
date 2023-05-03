using CookingHut.Services.Mapping.Dtos;
using CookingHut.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        [HttpGet("{id}")]
        public RecipeIngredientDto GetById(int id)
        {
            return _service.GetById(id).Result;
        }

        [HttpPost]
        public RecipeIngredientDto Save(RecipeIngredientDto recipeIngredientDto)
        {
            return _service.Save(recipeIngredientDto).Result;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            RecipeIngredientDto recipeIngredient = _service.GetById(id).Result;
            if (recipeIngredient != null)
                _service.Delete(recipeIngredient);
        }
    }
}