using CookingHut.Services.Mapping.Dtos;
using CookingHut.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingHut.Controllers
{
    [Route("CookingHut/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _service;

        public IngredientController(IIngredientService ingredientService)
        {
            _service = ingredientService;
        }

        [HttpGet]
        public List<IngredientDto> GetAll()
        {
            return _service.GetAll().Result;
        }

        [HttpGet("{id}")]
        public IngredientDto GetById(int id)
        {
            return _service.GetById(id).Result;
        }

        [HttpPost]
        public IngredientDto Save(IngredientDto ingredientDto)
        {
            return _service.Save(ingredientDto).Result;
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _service.Delete(id);
        }
    }
}