using Microsoft.AspNetCore.Mvc;

namespace NardSmena.Controllers
{
    public class ThemeController : Controller
    {
        public IActionResult ToogleTheme(string returnUrl)
        {
            var theme = Request.Cookies["theme"];

            theme = theme == "dark" ? "light" : "dark";

            Response.Cookies.Append("theme", theme);

            return Redirect(returnUrl);
        }
    }
}
