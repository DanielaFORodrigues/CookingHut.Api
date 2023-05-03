using CookingHut.Services.Mapping.Dtos;
using CookingHut.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CookingHut.Controllers
{
    [Route("CookingHut/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService categoryService)
        {
            _service = categoryService;
        }

        [HttpGet]
        public List<CategoryDto> GetAll()
        {
            return _service.GetAll().Result;
        }

        [HttpGet("{id}")]
        public CategoryDto GetById(int id)
        {
            return _service.GetById(id).Result;
        }

        [HttpPost]
        public CategoryDto Save(CategoryDto categoryDto)
        {
            return _service.Save(categoryDto).Result;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CategoryDto category = _service.GetById(id).Result;
            if (category != null)
                _service.Delete(category);
        }
    }
}