using EnglishTrainer.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.ApplicationCore.QueryOptions
{
    public abstract class BaseQueryOptions<TEntity> where TEntity : class
    {
        public PageOptions PageOptions { get; set; } = new PageOptions(1, 1, PageSize.AllElements);
    }
}
