using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.ApplicationCore.QueryOptions;
using EnglishTrainer.Infrastructure.Data.DBExtentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.Infrastructure.Data
{
    public class EFTrainerRepository<T> : IRepository<T> where T : BaseModel
    {
        private readonly EnglishTrainerContext _dbContext;

        public EFTrainerRepository(EnglishTrainerContext dbContext)
        {
              _dbContext= dbContext;
        }

        public async Task CreateAsync(T entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            //_dbContext.Remove(id);
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync(QueryEntityOptions<T> options)
        {
            return await _dbContext.Set<T>()
                .SkipTakeEntities(options.PageOptions.CurrentPage, options.PageOptions.PageSize)
                .ToListAsync();
        }

        //public async Task<T?> GetByIdAsync(int id)
        //{
        //    var entity = await _dbContext.Set<T>().FindAsync(id);
        //    return entity;
        //}

        public async Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            var entity = await _dbContext.Set<T>().IncludeFields(includes).FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
