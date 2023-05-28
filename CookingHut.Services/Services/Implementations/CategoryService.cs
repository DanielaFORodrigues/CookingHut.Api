using AutoMapper;
using CookingHut.Domain.Entities;
using CookingHut.Infra.Data.Context;
using CookingHut.Infra.Data.Repositories.Interfaces;
using CookingHut.Services.Mapping.Dtos;
using CookingHut.Services.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingHut.Services.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;
        private readonly CookingHutDBContext _context;

        public CategoryService(IMapper mapper, ICategoryRepository repository, CookingHutDBContext context)
        {
            _mapper = mapper;
            _context = context;
            _repository = repository;
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            List<Category> categories = await _repository.GetAll();
            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetById(int id)
        {
            Category category = await _repository.GetById(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> Save(CategoryDto categoryDto)
        {
            Category category = _mapper.Map<Category>(categoryDto);

            if (categoryDto.Id > 0)
            {
                _repository.Update(category);
            }
            else
            {
                _repository.Add(category);
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task Delete(int id)
        {
            Category category = await _repository.GetById(id);

            _repository.Delete(category);

            await _context.SaveChangesAsync();
        }
    }
}