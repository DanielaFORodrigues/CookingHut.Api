using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CookingHut.Infra.Data.Context;
using CookingHut.Infra.Data.Repositories.Implementations;
using CookingHut.Infra.Data.Repositories.Interfaces;
using CookingHut.Services.Mapping.AutoMapper;
using CookingHut.Services.Services.Implementations;
using CookingHut.Services.Services.Interfaces;
using CookingHut.Domain.Entities;

namespace CookingHut.Infra.CrossCutting.DependencyContainer
{
    public static class DependecyContainer
    {
        public static void AddApiConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<CookingHutDBContext>();
            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.RegisterRepositories();
            services.RegisterServices();
        }

        private static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IRecipeCommentsRepository, RecipeCommentsRepository>();
            services.AddScoped<IUserFavouriteRecipesRepository, UserFavouriteRecipesRepository>();
            services.AddScoped<IRecipeIngredientRepository, RecipeIngredientRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        private static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<IRecipeCommentsService, RecipeCommentsService>();
            services.AddScoped<IUserFavouriteRecipesService, UserFavouriteRecipesService>();
            services.AddScoped<IRecipeIngredientService, RecipeIngredientService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}