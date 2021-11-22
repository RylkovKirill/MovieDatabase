using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Common.Paging
{
    public class PagedListBase
    {
        public int Total { get; }
        public int Page { get; }
        public int PerPage { get; }

        public int TotalPages => Total % PerPage == 0 ? Total / PerPage : Total / PerPage + 1;
        public bool CanNext => Page < TotalPages;
        public bool CanPrevious => Page > 1;

        public PagedListBase(int total, PageInfo pageInfo)
        {
            Total = total;
            Page = pageInfo.Page;
            PerPage = pageInfo.PerPage;
        }
    }
}
