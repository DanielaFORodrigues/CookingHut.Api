using CookingHut.Services.Mapping.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingHut.Services.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAll();

        Task<CategoryDto> GetById(int id);

        Task<CategoryDto> Save(CategoryDto categoryDto);

        Task Delete(CategoryDto categoryDto);
    }
}