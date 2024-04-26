using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NardSmena.Models;
using System.Security.Claims;

namespace NardSmena.Controllers
{
	public class RoleAssignmentController : Controller
	{
		private readonly ApplicationContext _context;
		private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleAssignmentController(ApplicationContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
		{
			_context = context;
			_userManager = userManager;
            _roleManager = roleManager;
		}

		[Authorize(Roles = "admin")]
		[HttpGet]
		public IActionResult Index()
		{
			var roleAssignments = _context.RoleAssignments.ToList();
            int rowCount = _context.RoleAssignments.Count();

			var roleAssignmentsViewModels = roleAssignments.Select(ra => new RoleAssignmentViewModel
			{
				RoleAssignmentId = ra.RoleAssignmentId,
				FIO = ra.FIO,
				Department = ra.Department,
				SelectedRole = ra.SelectedRole
			}).ToList();

            ViewBag.RowCount = rowCount;

			return View(roleAssignmentsViewModels);
		}

        [HttpPost]
        public async Task<IActionResult> SendRoleAssignment(string selectedRole)
        {
            if (ModelState.IsValid)
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var user = await _userManager.FindByIdAsync(userId);

                if (user != null)
                {
                    string fio = user.FIO;
                    string department = user.Department;

                    var roleAssignment = new RoleAssignmentViewModel
                    {
                        UserId = userId,
                        FIO = fio,
                        Department = department,
                        SelectedRole = selectedRole

                    };

                    _context.RoleAssignments.Add(roleAssignment);

                    await _context.SaveChangesAsync();

                    TempData["SuccessMessagePost"] = "Ваша заявка на назначение роли успешно отправлена";

                    return Json(new { success = true});
                }
                else
                {
                    TempData["ErrorMessage"] = "Пользователь не найден";
                    return NotFound();
                }
            }

            return BadRequest(ModelState);
        }

        public async Task<IActionResult> GetRowCount()
        {
            try
            {
                int rowCount = await _context.RoleAssignments.CountAsync();

                return Json(rowCount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Произошла ошибка при получении количества записей: {ex.Message}");
            }
        }

		[HttpPost]
		public async Task<IActionResult> ApproveRole(int roleAssignmentId, string roleName)
		{
			try
			{
				var roleAssignment = await _context.RoleAssignments.FindAsync(roleAssignmentId);
				if (roleAssignment == null)
				{
					return NotFound("Заявка не найдена");
				}

				var userId = roleAssignment.UserId;

				var user = await _userManager.FindByIdAsync(userId);
				if (user == null)
				{
					return NotFound(new { errorMessage = "Пользователь не найден" });
				}

				if (!await _roleManager.RoleExistsAsync(roleName))
				{
					return Json(new { errorMessage = "Текущая роль не найдена в базе данных, отклоните заявку" });
				}

				if (await _userManager.IsInRoleAsync(user, roleName))
				{
					return BadRequest(new { errorMessage = "Пользователь уже имеет данную роль" });
				}

				_context.RoleAssignments.Remove(roleAssignment);
				await _context.SaveChangesAsync();

				var result = await _userManager.AddToRoleAsync(user, roleName);
				if (result.Succeeded)
				{
					return Json(new { success = $"Роль {roleName} успешно назначена пользователю {user.UserName}" });
				}
				else
				{
					return BadRequest(result.Errors);
				}
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Произошла ошибка при назначении роли: {ex.Message}");
			}
		}

		[HttpPost]
		public async Task<IActionResult> RejectRole(int roleAssignmentId)
		{
			try
			{
				var roleAssignment = await _context.RoleAssignments.FindAsync(roleAssignmentId);

				if (roleAssignment == null)
				{
					return Json(new { errorMessage = "Заявка не найдена" });
				}

				_context.RoleAssignments.Remove(roleAssignment);
				await _context.SaveChangesAsync();

				return Ok("Вы успешно отклонили заявку");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Произошла ошибка при отклонении заявки: {ex.Message}");
			}
		}
	}
}
