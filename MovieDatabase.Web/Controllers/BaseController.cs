using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Core;

namespace MovieDatabase.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IUnitOfWork Unit;

        protected BaseController(IUnitOfWork unit)
        {
            Unit = unit;
        }
    }
}
