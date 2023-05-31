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

        UserLogin GetLogin(UserLogin userLogin);

        Task<UserDto> Create(UserDto userDto);

        Task<UserDto> Update(UserDto userDto);

        Task<UserDto> Block(int id, bool shouldBlock);

        Task<UserDto> PromoteAdmin(int id, bool shouldBeAdmin);

        Task Delete(int id);
    }
}