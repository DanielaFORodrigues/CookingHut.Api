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
    public class UserFavouriteRecipesService : IUserFavouriteRecipesService
    {
        private readonly IMapper _mapper;
        private readonly IUserFavouriteRecipesRepository _repository;
        private readonly CookingHutDBContext _context;

        public UserFavouriteRecipesService(IMapper mapper, IUserFavouriteRecipesRepository repository, CookingHutDBContext context)
        {
            _mapper = mapper;
            _context = context;
            _repository = repository;
        }

        public async Task<List<UserFavouriteRecipeDto>> GetAll()
        {
            List<UserFavouriteRecipe> userFavouriteRecipes = await _repository.GetAll();
            return _mapper.Map<List<UserFavouriteRecipeDto>>(userFavouriteRecipes);
        }

        public async Task<UserFavouriteRecipeDto> GetById(int recipeId, int userId)
        {
            UserFavouriteRecipe userFavouriteRecipes = await _repository.GetById(recipeId, userId);
            return _mapper.Map<UserFavouriteRecipeDto>(userFavouriteRecipes);
        }

        public async Task<UserFavouriteRecipeDto> Save(UserFavouriteRecipeDto userFavouriteRecipeDto)
        {
            UserFavouriteRecipe userFavouriteRecipe = _mapper.Map<UserFavouriteRecipe>(userFavouriteRecipeDto);

            _repository.Add(userFavouriteRecipe);

            await _context.SaveChangesAsync();

            return _mapper.Map<UserFavouriteRecipeDto>(userFavouriteRecipe);
        }

        public async Task Delete(int recipeId, int userId)
        {
            UserFavouriteRecipe userFavouriteRecipe = await _repository.GetById(recipeId, userId);

            _repository.Delete(userFavouriteRecipe);

            await _context.SaveChangesAsync();
        }
    }
}