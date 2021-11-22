using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Core;
using MovieDatabase.Web.Controllers;

namespace MovieDatabase.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]")]
    public abstract class BaseAdminController : BaseController
    {
        protected BaseAdminController(IUnitOfWork unit) : base(unit) { }
    }
}
