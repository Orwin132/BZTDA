using Microsoft.AspNetCore.Mvc;
using NardSmena.Models;

namespace NardSmena.Controllers
{
    public class SettingsController : Controller
    {
        [HttpGet]
        public IActionResult Settings()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SwitchTheme(string theme)
        {
            HttpContext.Session.SetString("Theme", theme);

            return Json(new {success = true });
        }
    }
}
