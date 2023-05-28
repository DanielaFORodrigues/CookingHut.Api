using AutoMapper;
using CookingHut.Domain.Entities;
using CookingHut.Infra.Data.Context;
using CookingHut.Infra.Data.Repositories.Interfaces;
using CookingHut.Services.Mapping.Dtos;
using CookingHut.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingHut.Services.Services.Implementations
{
    public class RecipeCommentsService : IRecipeCommentsService
    {
        private readonly IMapper _mapper;
        private readonly IRecipeCommentsRepository _repository;
        private readonly CookingHutDBContext _context;

        public RecipeCommentsService(IMapper mapper, IRecipeCommentsRepository repository, CookingHutDBContext context)
        {
            _mapper = mapper;
            _context = context;
            _repository = repository;
        }

        public async Task<List<RecipeCommentDto>> GetAll()
        {
            List<RecipeComment> recipeComments = await _repository.GetAll();
            return _mapper.Map<List<RecipeCommentDto>>(recipeComments);
        }

        public async Task<List<RecipeCommentDto>> GetByRecipeId(int recipeId)
        {
            List<RecipeComment> recipeComments = await _repository.GetByRecipeId(recipeId);
            return _mapper.Map<List<RecipeCommentDto>>(recipeComments);
        }

        public async Task<RecipeCommentDto> GetById(int id)
        {
            RecipeComment recipeComment = await _repository.GetById(id);
            return _mapper.Map<RecipeCommentDto>(recipeComment);
        }

        public async Task<RecipeCommentDto> Save(RecipeCommentDto recipeIngredientDto)
        {
            RecipeComment recipeComments = _mapper.Map<RecipeComment>(recipeIngredientDto);

            if (recipeIngredientDto.Id > 0)
            {
                _repository.Update(recipeComments);
            }
            else
            {
                _repository.Add(recipeComments);
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<RecipeCommentDto>(recipeComments);
        }

        public async Task Delete(int id)
        {
            RecipeComment recipeComment = await _repository.GetById(id);

            _repository.Delete(recipeComment);

            await _context.SaveChangesAsync();
        }
    }
}