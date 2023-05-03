using CookingHut.Domain.Entities;
using CookingHut.Services.Mapping.Dtos;
using CookingHut.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingHut.Controllers
{
    [Route("CookingHut/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService userService)
        {
            _service = userService;
        }

        [HttpGet]
        public async Task<List<UserDto>> GetAllAsync()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var user = await _service.GetById(id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult GetLogin(UserLogin user)
        {
            var loggedUser = _service.GetLogin(user.Email, user.Password);

            if (loggedUser is null)
            {
                return Unauthorized();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUserAsync(UserDto userDto)
        {
            var user = await _service.Create(userDto);

            if (user is null)
            {
                return Conflict();
            }

            return Ok(user);
        }

        [HttpPut]
        public async Task<UserDto> UpdateAsync(UserDto userDto)
        {
            return await _service.Update(userDto);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _service.Delete(id);
        }
    }
}