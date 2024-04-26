using Microsoft.AspNetCore.Mvc;
using NardSmena.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using NardSmena.Interfaces;

namespace NardSmena.Controllers
{
    public class InputController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ICopyDataService _copyDataService;

        public InputController(IWebHostEnvironment environment, ICopyDataService copyDataService)
        {
            _environment = environment;
            _copyDataService = copyDataService;
        }

        [HttpGet]
        public IActionResult VvodNariad()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VvodNariad(int month)
        {
            _copyDataService.CopyData(month);

            return View();
        }


        public IActionResult VvodBrigad()
        {
            return View();
        }
    }
}
