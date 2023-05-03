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
    public class RecipeService : IRecipeService

    {
        private readonly IMapper _mapper;
        private readonly IRecipeRepository _repository;
        private readonly CookingHutDBContext _context;

        public RecipeService(IMapper mapper, IRecipeRepository repository, CookingHutDBContext context)
        {
            _mapper = mapper;
            _context = context;
            _repository = repository;
        }

        public async Task<List<RecipeDto>> GetAll()
        {
            List<Recipe> recipes = await _repository.GetAll();
            return _mapper.Map<List<RecipeDto>>(recipes);
        }

        public async Task<RecipeDto> GetById(int id)
        {
            Recipe recipe = await _repository.GetById(id);
            return _mapper.Map<RecipeDto>(recipe);
        }

        public async Task<RecipeDto> Save(RecipeDto recipeDto)
        {
            Recipe recipe = _mapper.Map<Recipe>(recipeDto);

            if (recipeDto.Id > 0)
            {
                _repository.Update(recipe);
            }
            else
            {
                _repository.Add(recipe);
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<RecipeDto>(recipe);
        }

        public async Task Delete(RecipeDto recipeDto)
        {
            Recipe recipe = _mapper.Map<Recipe>(recipeDto);

            _repository.Delete(recipe);

            await _context.SaveChangesAsync();
        }
    }
}