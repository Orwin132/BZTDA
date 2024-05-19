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
            var msFndVrList = await _context.MsFndVr.ToListAsync();

            var viewModel = new CombinedViewModelSprOperation
            {
                TarifList = tarifList,
                OtpVredList = otpVredList,
                SprOperList = sprOperList,
                SprDetList = sprDetList,
                MsFndVrList = msFndVrList
            };

            return View(viewModel);
        }

        [Authorize(Roles = "admin, ceh1, ceh2")]
        public async Task<IActionResult> SprRab()
        {
            var sprRabList = await _context.SPRRAB.ToListAsync();
            var proffList = await _context.PROFF.ToListAsync();

            var viewModel = new CombinedViewModelSprRab
            {
                SprRabList = sprRabList,
                ProffList = proffList
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
            try
            {
                var kodDetal = await _context.SprDet.FirstOrDefaultAsync(d => d.KodDetal == kodDetalDelete);

                if (kodDetal == null)
                {
                    return Json(new { success = false, message = "Запись не найдена" });
                }

                // Найти все связанные записи в таблице Sproper
                var relatedRecords = await _context.Sproper.Where(s => s.KodDetal == kodDetalDelete).ToListAsync();

                _context.Sproper.RemoveRange(relatedRecords);

                _context.SprDet.Remove(kodDetal);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Текущая запись была успешно удалена!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Произошла ошибка при удалении записи: {ex.Message}" });
            }
        }

        public ActionResult Compare()
        {
            try
            {
                if (!_context.Sravnenie.Any())
                {
                    return Json(new { success = false, message = "Сравнительная таблица пуста. Сравнительный анализ не выполнен." });
                }

                var sprOper = _context.Sproper.ToList();
                var sravnenie = _context.Sproper.ToList();

                var commonRecords = sprOper.Intersect(sravnenie).ToList();

                TempData["CommonRecords"] = commonRecords;

                return Json(new { success = true, message = "Сравнительный анализ успешно выполнен", data = commonRecords });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Произошла ошибка при выоплнении сравнительного анализа: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> RashRascenki()
        {
            try
            {
                // Получаем данные из таблицы SprOper
                var sprOperData = await _context.Sproper.ToListAsync();

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
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Операция успешно выполнена. Данные обновлены" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Произошла ошибка выполнения операции: {ex.Message}" });
            }
        }

        private string NormalizeOperationName(string name)
        {
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
            if (sprOper.Procent == null)
                return Okrug(( sprOper.TimeOperation * TR ) / 60);
            else
                return Okrug(( sprOper.TimeOperation * TR ) * ( 1 + sprOper.Procent / 100 ) / 60);
        }

        private double Okrug(double value)
        {
            return Math.Round(value, 3);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTable([FromBody] SprOper_SprDet request)
        {
            try
            {
                foreach (var updatedSprOper in request.Sproper)
                {
                    var sprOper = await _context.Sproper.FirstOrDefaultAsync(s => s.NomStr == updatedSprOper.NomStr);

                    if (sprOper != null)
                    {
                        sprOper.KodDetal = updatedSprOper.KodDetal;
                        sprOper.TimeComput = updatedSprOper.TimeComput;
                        sprOper.Rascenka = updatedSprOper.Rascenka;
                    }
                }

                foreach (var updatedSprDet in request.SprDet)
                {
                    var sprDet = await _context.SprDet.FirstOrDefaultAsync(d => d.KodDetal == updatedSprDet.KodDetal);

                    if (sprDet != null)
                    {
                        sprDet.KodDetal = updatedSprDet.KodDetal;
                        sprDet.NameDetal = updatedSprDet.NameDetal;
                        sprDet.ShifrDetal = updatedSprDet.ShifrDetal;
                    }
                }

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Данные успешно обновлены" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Произошла ошибка: {ex.Message}" });
            }
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
