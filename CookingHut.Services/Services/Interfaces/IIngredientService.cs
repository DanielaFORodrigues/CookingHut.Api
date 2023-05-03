using CookingHut.Domain.Entities;
using CookingHut.Services.Mapping.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingHut.Services.Services.Interfaces
{
    public interface IIngredientService
    {
        Task<List<IngredientDto>> GetAll();

        Task<IngredientDto> GetById(int id);

        Task<IngredientDto> Save(IngredientDto ingredientDto);

        Task Delete(IngredientDto ingredientDto);
    }
}