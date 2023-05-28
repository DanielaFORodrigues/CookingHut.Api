using CookingHut.Domain.Entities;
using CookingHut.Services.Mapping.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingHut.Services.Services.Interfaces
{
    public interface IRatingService
    {
        Task<List<RatingDto>> GetAll();

        Task<RatingDto> GetById(int id);

        Task<RatingDto> Save(RatingDto ratingDto);

        Task Delete(int id);
    }
}