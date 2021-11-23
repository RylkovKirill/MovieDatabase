using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabase.Web.Areas.Admin.Controllers
{
    public class HistoryController : BaseAdminController
    {
        public HistoryController(IUnitOfWork unit) : base(unit) { }

        public IActionResult Index()
        {
            return View();
        }
    }
}
