using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Common.Paging
{
    public class PagedList<T> : PagedListBase
    {
        public IReadOnlyList<T> Items { get; }

        public int From => (Page - 1) * PerPage + 1;
        public int To => From + Items.Count - 1;

        public PagedList(IList<T> items, int total, int page = 1, int perPage = int.MaxValue) : this(items, total,
            new PageInfo(page, perPage))
        {
        }

        public PagedList(IList<T> items, int total, PageInfo pageInfo) : base(total, pageInfo)
        {
            Items = new ReadOnlyCollection<T>(items);
        }

        public PagedList<TResult> Convert<TResult>(Func<T, TResult> func)
        {
            return new PagedList<TResult>(Items.Select(func).ToList(), Total, Page, PerPage);
        }
    }
}
