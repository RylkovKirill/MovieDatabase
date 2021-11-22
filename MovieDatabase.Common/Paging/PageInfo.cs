using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Common.Paging
{
    public class PageInfo
    {
        public int Page { get; }
        public int PerPage { get; }

        public PageInfo(int page = 1, int perPage = int.MaxValue)
        {
            Page = page;
            PerPage = perPage;
        }
    }
}
