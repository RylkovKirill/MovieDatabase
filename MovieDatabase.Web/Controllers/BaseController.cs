using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Core;

namespace MovieDatabase.Web.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        protected readonly IUnitOfWork Unit;

        protected BaseController(IUnitOfWork unit)
        {
            Unit = unit;
        }
    }
}
