using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieDatabase.Web.Areas.Admin.Views.History
{
    public static class HistoryNavPages
    {

        public static string MoviesHistory => "Movies History";

        public static string ReviewsHistory => "Reviews History";

        public static string MoviesNavClass(ViewContext viewContext) => PageNavClass(viewContext, MoviesHistory);

        public static string ReviewsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ReviewsHistory);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
