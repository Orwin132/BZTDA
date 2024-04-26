using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NardSmena.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace NardSmena.Controllers
{
    public class UserController : Controller
    {
        UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [Authorize(Roles = "admin")]
        public IActionResult Index() => View();

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UserManagement()
        {
            var users = _userManager.Users.ToList();


            var userRoles = new Dictionary<User, IList<string>>();
            foreach (var user in users)
            {
                userRoles[user] = await _userManager.GetRolesAsync(user);
            }


            return View(userRoles);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create (CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = model.UserName,
                    FIO = model.FIO,
                    Department = model.Department
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("UserManagement");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit (string id)
        {
            User user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            EditUserViewModel model = new EditUserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                FIO = user.FIO,
                Department = user.Department,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);

                if (user != null)
                {
                    user.UserName = model.UserName;
                    user.FIO = model.FIO;
                    user.Department = model.Department;
                    

                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("UserManagement");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }

            return RedirectToAction("UserManagement");
        }
    }
}
