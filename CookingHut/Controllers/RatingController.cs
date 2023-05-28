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

        [HttpGet]
        public List<RatingDto> GetAll()
        {
            return _service.GetAll().Result;
        }

        [HttpGet("{id}")]
        public RatingDto GetById(int id)
        {
            return _service.GetById(id).Result;
        }

        [HttpPost]
        public RatingDto Save(RatingDto ratingDto)
        {
            return _service.Save(ratingDto).Result;
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _service.Delete(id);
        }
    }
}