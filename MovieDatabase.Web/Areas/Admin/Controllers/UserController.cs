using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Core;
using MovieDatabase.Core.Entities.Membership;
using MovieDatabase.Infrastructure;

namespace MovieDatabase.Web.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UserController(IUnitOfWork unit, UserManager<User> userManager, RoleManager<Role> roleManager) : base(unit)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Route("[controller]")]
        public IActionResult List()
        {
            return View(_userManager.Users);
        }

        [Route("[controller]/[action]/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [Route("[controller]/[action]/{id:guid}")]
        public async Task<IActionResult> Roles(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }
            var roles = await _userManager.GetRolesAsync(user);
            ViewBag.Roles = roles;
            ViewBag.PotentialRoles = _roleManager.Roles.Where(r => !roles.ToList().Contains(r.Name)).ToList();
            return View(user);
        }

        [HttpPost("[controller]/AddRole/{id:guid}")]
        public async Task<IActionResult> AddRoleAsync(Guid id, Guid roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }

            await _userManager.AddToRoleAsync(user, role.Name);

            return RedirectToAction(nameof(Roles), new { id });
        }

        [HttpPost("[controller]/RemoveRole/{id:guid}")]
        public async Task<IActionResult> RemoveRoleAsync(Guid id, string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }

            await _userManager.RemoveFromRoleAsync(user, role.Name);

            return RedirectToAction(nameof(Roles), new { id });
        }
    }
}
