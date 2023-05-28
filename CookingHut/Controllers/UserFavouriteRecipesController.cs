using CookingHut.Domain.Entities;
using CookingHut.Infra.Data.Migrations;
using CookingHut.Services.Mapping.Dtos;
using CookingHut.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingHut.Controllers
{
    [Route("CookingHut/[controller]")]
    [ApiController]
    public class UserFavouriteRecipesController : ControllerBase

    {
        private readonly IUserFavouriteRecipesService _service;

        public UserFavouriteRecipesController(IUserFavouriteRecipesService userFavouriteRecipes)
        {
            _service = userFavouriteRecipes;
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int recipeId, int userId)
        {
            var userFavouriteRecipe = await _service.GetById(recipeId, userId);

            if (userFavouriteRecipe is null)
            {
                return NotFound();
            }

            return Ok(userFavouriteRecipe);
        }

        [HttpPost]
        public UserFavouriteRecipeDto Save(UserFavouriteRecipeDto userFavouriteRecipeDto)
        {
            return _service.Save(userFavouriteRecipeDto).Result;
        }

        [HttpDelete]
        public async Task DeleteAsync(int recipeId, int userId)
        {
            await _service.Delete(recipeId, userId);
        }
    }
}