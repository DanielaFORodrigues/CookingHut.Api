﻿using CookingHut.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingHut.Infra.Data.Repositories.Interfaces
{
    public interface IRatingRepository
    {
        Task<List<Rating>> GetAll(int recipeId);

        Task<Rating> GetById(int recipeId, int userId);

        Rating Add(Rating rating);

        Rating Update(Rating rating);

        void Delete(Rating rating);
    }
}