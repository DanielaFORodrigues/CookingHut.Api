using CookingHut.Domain.Entities;
using CookingHut.Services.Mapping.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingHut.Services.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAll();

        Task<UserDto> GetById(int id);

        User GetLogin(string email, string password);

        Task<UserDto> Save(UserDto userDto);

        Task Delete(UserDto userDto);
    }
}