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
    public class RatingService : IRatingService
    {
        private readonly IMapper _mapper;
        private readonly IRatingRepository _repository;
        private readonly CookingHutDBContext _context;

        public RatingService(IMapper mapper, IRatingRepository repository, CookingHutDBContext context)
        {
            _mapper = mapper;
            _context = context;
            _repository = repository;
        }

        public async Task<List<RatingDto>> GetAll()
        {
            List<Rating> ratings = await _repository.GetAll();
            return _mapper.Map<List<RatingDto>>(ratings);
        }

        public async Task<RatingDto> GetById(int id)
        {
            Rating rating = await _repository.GetById(id);
            return _mapper.Map<RatingDto>(rating);
        }

        public async Task<RatingDto> Save(RatingDto ratingDto)
        {
            Rating rating = _mapper.Map<Rating>(ratingDto);

            if (ratingDto.Id > 0)
            {
                _repository.Update(rating);
            }
            else
            {
                _repository.Add(rating);
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<RatingDto>(rating);
        }

        public async Task Delete(RatingDto ratingDto)
        {
            Rating rating = _mapper.Map<Rating>(ratingDto);

            _repository.Delete(rating);

            await _context.SaveChangesAsync();
        }
    }
}