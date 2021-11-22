using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Common.Paging
{
    public static class Queryable
    {
        public static IQueryable<T> SelectPage<T>(this IQueryable<T> query, PageInfo pageInfo)
        {
            return query.Skip((pageInfo.Page - 1) * pageInfo.PerPage).Take(pageInfo.PerPage);
        }
    }
}
