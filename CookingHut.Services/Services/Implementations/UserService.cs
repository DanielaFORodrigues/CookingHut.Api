using AutoMapper;
using CookingHut.Domain.Entities;
using CookingHut.Infra.Data.Context;
using CookingHut.Infra.Data.Repositories.Implementations;
using CookingHut.Infra.Data.Repositories.Interfaces;
using CookingHut.Services.Mapping.Dtos;
using CookingHut.Services.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingHut.Services.Services.Implementations
{
    public class UserService : IUserService

    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;
        private readonly CookingHutDBContext _context;

        public UserService(IMapper mapper, IUserRepository repository, CookingHutDBContext context)
        {
            _mapper = mapper;
            _context = context;
            _repository = repository;
        }

        public async Task<List<UserDto>> GetAll()
        {
            List<User> users = await _repository.GetAll();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetById(int id)
        {
            User user = await _repository.GetById(id);
            return _mapper.Map<UserDto>(user);
        }

        public User GetLogin(string email, string password)
        {
            return _repository.GetLogin(email, password);
        }

        public async Task<UserDto> Save(UserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);

            if (userDto.Id > 0)
            {
                _repository.Update(user);
            }
            else
            {
                _repository.Add(user);
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task Delete(UserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);

            _repository.Delete(user);

            await _context.SaveChangesAsync();
        }
    }
}