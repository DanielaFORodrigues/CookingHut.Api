using CookingHut.Domain.Entities;
using CookingHut.Services.Mapping.Dtos;
using CookingHut.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public List<UserDto> GetAll()
        {
            return _service.GetAll().Result;
        }

        [HttpGet("{id}")]
        public UserDto GetById(int id)
        {
            return _service.GetById(id).Result;
        }

        [HttpPost("login")]
        public User GetLogin(UserLogin user)
        {
            return _service.GetLogin(user.Email, user.Password);
        }

        [HttpPost]
        public UserDto Save(UserDto userDto)
        {
            return _service.Save(userDto).Result;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            UserDto user = _service.GetById(id).Result;
            if (user != null)
                _service.Delete(user);
        }
    }
}