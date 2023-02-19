using EnglishTrainer.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.Infrastructure.Data.DBExtentions
{
    public static class TEntityListSkipTake
    {
        public static IQueryable<TEntity> SkipTakeEntities<TEntity>(this IQueryable<TEntity> entities, int currentPage, PageSize pageSize)
        {
            int ps = (int)pageSize;
            return pageSize switch
            {
                PageSize.AllElements => entities,
                _ => entities.Skip((currentPage - 1) * ps)
                             .Take(ps)
            };

        }
    }
}
