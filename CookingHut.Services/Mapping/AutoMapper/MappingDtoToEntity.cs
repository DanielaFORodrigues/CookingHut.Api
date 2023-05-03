using AutoMapper;
using CookingHut.Domain.Entities;
using CookingHut.Services.Mapping.Dtos;

namespace CookingHut.Services.Mapping.AutoMapper
{
    public class MappingDtoToEntity : Profile
    {
        public MappingDtoToEntity()

        {
            CreateMap<CategoryDto, Category>();//.ForMember(dest => dest.UserId, opt => opt.Ignore());
            CreateMap<RecipeDto, Recipe>();
            CreateMap<IngredientDto, Ingredient>();//.ForMember(dest => dest.UserId, opt => opt.Ignore());
            CreateMap<RatingDto, Rating>();//.ForMember(dest => dest.UserId, opt => opt.Ignore());
            CreateMap<RecipeIngredientDto, RecipeIngredient>();//.ForMember(dest => dest.UserId, opt => opt.Ignore());
            CreateMap<UserDto, User>();//.ForMember(dest => dest.UserId, opt => opt.Ignore());
        }
    }
}