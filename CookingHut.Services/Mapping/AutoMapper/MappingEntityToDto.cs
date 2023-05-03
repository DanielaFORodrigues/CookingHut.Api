using AutoMapper;
using CookingHut.Domain.Entities;
using CookingHut.Services.Mapping.Dtos;

namespace CookingHut.Services.Mapping.AutoMapper
{
    public class MappingEntityToDto : Profile
    {
        public MappingEntityToDto()
        {
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Rating, RatingDto>();
            CreateMap<Recipe, RecipeDto>();
            CreateMap<RecipeIngredient, RecipeIngredientDto>();
            CreateMap<User, UserDto>();
        }
    }
}