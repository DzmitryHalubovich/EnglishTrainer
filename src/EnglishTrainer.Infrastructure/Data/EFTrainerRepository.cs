using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.ApplicationCore.QueryOptions;
using EnglishTrainer.Infrastructure.Data.DBExtentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.Infrastructure.Data
{
    public class EFTrainerRepository<T> : IRepository<T> where T : class
    {
        private readonly EnglishTrainerContext _dbContext;

        public EFTrainerRepository(EnglishTrainerContext dbContext)
        {
              _dbContext= dbContext;
        }

        public IEnumerable<Verb> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync(QueryEntityOptions<T> options)
        {
            return await _dbContext.Set<T>()
                .SkipTakeEntities(options.PageOptions.CurrentPage, options.PageOptions.PageSize)
                .ToListAsync();
        }

    }
}
