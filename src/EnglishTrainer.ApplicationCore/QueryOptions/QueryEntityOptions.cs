using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.ApplicationCore.QueryOptions
{
    public sealed class QueryEntityOptions<TEntity> : BaseQueryOptions<TEntity> where TEntity : class
    {
        public QueryEntityOptions<TEntity> SetCurentPageAndPageSize(PageOptions options)
        {
            PageOptions.PageSize = options.PageSize;
            if (options.CurrentPage > 0)
            {
                PageOptions.CurrentPage = options.CurrentPage;
            }
            return this;
        }
        public QueryEntityOptions<TEntity> NextPage()
        {
            PageOptions.CurrentPage++;
            return this;
        }

        public QueryEntityOptions<TEntity> PrevPage()
        {
            if (PageOptions.CurrentPage > 1)
            {
                PageOptions.CurrentPage--;
            }
            return this;
        }
    }
}
