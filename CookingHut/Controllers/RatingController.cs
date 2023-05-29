using CookingHut.Services.Mapping.Dtos;
using CookingHut.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingHut.Controllers
{
    [Route("CookingHut/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _service;

        public RatingController(IRatingService ratingService)
        {
            _service = ratingService;
        }

        [HttpGet("{recipeId}")]
        public List<RatingDto> GetAll(int recipeId)
        {
            return _service.GetAll(recipeId).Result;
        }

        [HttpGet("{recipeId}/{userId}")]
        public async Task<IActionResult> GetByIdAsync(int recipeId, int userId)
        {
            var rating = await _service.GetById(recipeId, userId);

            if (rating is null)
            {
                return NotFound();
            }

            return Ok(rating);
        }

        [HttpPost]
        public RatingDto Save(RatingDto ratingDto)
        {
            return _service.Save(ratingDto).Result;
        }
    }
}