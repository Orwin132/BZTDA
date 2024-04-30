using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using NardSmena.Models;
using System.Data.SqlClient;
using System.Security.Claims;

namespace NardSmena.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<User> _userManager;

        public HomeController(ApplicationContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Account", "AccessDenied");
            }

            ViewBag.SuccessMessage = TempData["SuccessMessage"] as string;

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            var userRoles = await _userManager.GetRolesAsync(user);

            ViewBag.UserRoles = userRoles;

            return View();
        }

        [Authorize(Roles="admin, ceh1, ceh2")]
        public IActionResult Tabel()
        {
            return View();
        }

        [Authorize(Roles="admin, ceh1, ceh2")]
        public IActionResult Uchet()
        {
            return View();
        }

        [Authorize(Roles = "admin, ceh1, ceh2")]
        public async Task<IActionResult> SprOperation()
        {
            var tarifList = await _context.TARIF.ToListAsync();
            var otpVredList = await _context.OtpVred.ToListAsync();
            var sprOperList = await _context.Sproper.ToListAsync();
            var sprDetList = await _context.SprDet.ToListAsync();

            var viewModel = new CombinedViewModelSprOperation
            {
                TarifList = tarifList,
                OtpVredList = otpVredList,
                SprOperList = sprOperList,
                SprDetList = sprDetList
            };

            return View(viewModel);
        }

        [Authorize(Roles = "admin, ceh1, ceh2")]
        public async Task<IActionResult> SprRab()
        {
            var sprRabList = await _context.SPRRAB.ToListAsync();

            var viewModel = new CombinedViewModelSprRab
            {
                SprRabList = sprRabList
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> CopyOperation(string id)
        {
            try
            {
                var originalDetail = await _context.SprDet.FindAsync(id);

                if (originalDetail == null)
                {
                    return NotFound();
                }

                if (originalDetail.KodDetal.Length >= 25)
                {
                    return new StatusCodeResult(400);
                }

                var copyDetail = new SprDet
                {
                    KodDetal = originalDetail.KodDetal + "_Копия",
                    NameDetal = originalDetail.NameDetal + "_Копия",
                    ShifrDetal = originalDetail.ShifrDetal + "_Копия",
                };

                _context.SprDet.Add(copyDetail);
               await _context.SaveChangesAsync();

                var operations = _context.Sproper.Where(op => op.KodDetal == originalDetail.KodDetal).ToList();

                foreach (var operation in operations)
                {
                    var copyOperation = new Sproper
                    {
                        KodDetal = copyDetail.KodDetal,
                        KodOperation = operation.KodOperation,
                        NameOperation = operation.NameOperation,
                        Razriad = operation.Razriad,
                        TimeComput = operation.TimeComput,
                        TimeOperation = operation.TimeOperation,
                        Procent = operation.Procent,
                        Rascenka = operation.Rascenka,
                        GrTarif = operation.GrTarif,
                        DpPrem = operation.DpPrem,
                        KoefDV = operation.KoefDV
                    };

                    _context.Sproper.Add(copyOperation);
                }

               await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Текущая деталь успешно скопирована!" });
            } 
            catch (Exception ex)
            {
                return Json(new {success = false, message = $"Произошла ошибка при копировании строки: {ex.Message}"});
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteRow(string kodDetalDelete)
        {
            var kodDetal = await _context.SprDet.FirstOrDefaultAsync(d => d.KodDetal == kodDetalDelete);

            if (kodDetal == null)
            {
                return NotFound();
            }

            _context.SprDet.Remove(kodDetal);
            await _context.SaveChangesAsync();

            return RedirectToAction("SprOperation", "Home");
        }

        public IActionResult RashRascenki()
        {
            // Проверяем, находится ли SprOper в состоянии редактирования или вставки,
            // и сохраняем изменения, если необходимо
            if (_context.Sproper.Any(s => _context.Entry(s).State == EntityState.Modified || _context.Entry(s).State == EntityState.Added))
                _context.SaveChanges();

            // Если SprOper находится в состоянии просмотра
            if (_context.Sproper.All(s => _context.Entry(s).State == EntityState.Unchanged))
            {
                // Получаем данные из таблицы SprOper
                var sprOperData = _context.Sproper.ToList();

                foreach (var sprOper in sprOperData)
                {
                    // Редактируем запись
                    sprOper.NameOperation = NormalizeOperationName(sprOper.NameOperation);

                    // Определяем группу тарифа
                    double TR = GetTarif(sprOper.GrTarif);

                    // Рассчитываем расценку
                    sprOper.Rascenka = CalculateRascenka(sprOper, TR);

                    // Устанавливаем минимальное значение для расценки
                    if (sprOper.Rascenka < 0.001 && sprOper.TimeOperation > 0)
                        sprOper.Rascenka = 0.001;

                    // Обновляем состояние сущности
                    _context.Update(sprOper);
                }

                // Сохраняем изменения
                _context.SaveChanges();
            }

            // Возвращаем пользователю какой-либо результат (например, перенаправляем на другую страницу)
            return RedirectToAction("Index", "Home");
        }

        private string NormalizeOperationName(string name)
        {
            // Нормализуем названия операций
            if (name != null)
            {
                if (name.StartsWith("слесарная")) name = "слесарная";
                else if (name.StartsWith("фрезерная")) name = "фрезерная";
                else if (name.StartsWith("шлифовальная")) name = "шлифовальная";
                else if (name.StartsWith("автоматическая")) name = "автоматная";
                else if (name.StartsWith("токарная")) name = "токарная";
                else if (name.StartsWith("сверлильная")) name = "сверлильная";
            }
            return name;
        }

        private double GetTarif(int group)
        {
            // Получаем тариф в зависимости от группы
            switch (group)
            {
                case 1: return _context.TARIF.First().Tarif1;
                case 2: return _context.TARIF.First().Tarif;
                case 3: return _context.TARIF.First().Tarif3;
                default: return 0.0;
            }
        }

        private double CalculateRascenka(Sproper sprOper, double TR)
        {
            // Рассчитываем расценку в зависимости от наличия процента
            if (sprOper.Procent == null)
                return Okrug(( sprOper.TimeOperation * TR ) / 60);
            else
                return Okrug(( sprOper.TimeOperation * TR ) * ( 1 + sprOper.Procent / 100 ) / 60);
        }

        private double Okrug(double value)
        {
            // Округляем значение
            return Math.Round(value, 3);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            var record = await _context.Sproper.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            _context.Sproper.Remove(record);
            await _context.SaveChangesAsync();

            return Ok();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                base.OnActionExecuted(filterContext);

                if (_context.ChangeTracker.HasChanges())
                {
                    _context.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                TempData["ErrorMessage"] = $"Произошла ошибка при сохранении изменений в базе данных: {ex.Message}";
            }
        }
    }
}
