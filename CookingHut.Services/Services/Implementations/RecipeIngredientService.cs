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
    public class RecipeIngredientService : IRecipeIngredientService

    {
        private readonly IMapper _mapper;
        private readonly IRecipeIngredientRepository _repository;
        private readonly CookingHutDBContext _context;

        public RecipeIngredientService(IMapper mapper, IRecipeIngredientRepository repository, CookingHutDBContext context)
        {
            _mapper = mapper;
            _context = context;
            _repository = repository;
        }

        public async Task<List<RecipeIngredientDto>> GetAll()
        {
            List<RecipeIngredient> recipeIngredients = await _repository.GetAll();
            return _mapper.Map<List<RecipeIngredientDto>>(recipeIngredients);
        }

        public async Task<RecipeIngredientDto> GetByRecipeId(int recipeId)
        {
            RecipeIngredient recipeIngredient = await _repository.GetByRecipeId(recipeId);
            return _mapper.Map<RecipeIngredientDto>(recipeIngredient);
        }

        public async Task<RecipeIngredientDto> Save(RecipeIngredientDto recipeIngredientDto)
        {
            RecipeIngredient recipeIngredient = _mapper.Map<RecipeIngredient>(recipeIngredientDto);

            if (recipeIngredientDto.Id > 0)
            {
                _repository.Update(recipeIngredient);
            }
            else
            {
                _repository.Add(recipeIngredient);
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<RecipeIngredientDto>(recipeIngredient);
        }

        public async Task Delete(RecipeIngredientDto recipeIngredientDto)
        {
            RecipeIngredient recipeIngredient = _mapper.Map<RecipeIngredient>(recipeIngredientDto);

            _repository.Delete(recipeIngredient);

            await _context.SaveChangesAsync();
        }
    }
}