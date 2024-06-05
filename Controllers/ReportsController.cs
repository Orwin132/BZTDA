﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NardSmena.Models;

namespace NardSmena.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationContext _context;

        public ReportsController(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> PrintLaborStandardsSprOperation(string printTitle)
        {
            var sprOper = await _context.Sproper.ToListAsync();
            var sprDet = await _context.SprDet.ToListAsync();

            ViewData["PrintTitle"] = printTitle;

            var viewModel = new CombinedViewModelSprOperation
            {
                SprDetList = sprDet,
                SprOperList = sprOper
            };

            return View(viewModel);
        }

        public async Task<IActionResult> PrintTimeStandards(string printTitle)
        {
            var sprOper = await _context.Sproper.ToListAsync();
            var sprDet = await _context.SprDet.ToListAsync();

            ViewData["PrintTitle"] = printTitle;

            var viewModel = new CombinedViewModelSprOperation
            {
                SprDetList = sprDet,
                SprOperList = sprOper
            };

            return View(viewModel);
        }

        public async Task<IActionResult> PrintSprOperation(string printTitle)
        {
            var sprOper = await _context.Sproper.ToListAsync();
            var sprDet = await _context.SprDet.ToListAsync();

            ViewData["PrintTitle"] = printTitle;

            var viewModel = new CombinedViewModelSprOperation
            {
                SprDetList = sprDet,
                SprOperList = sprOper
            };

            return View(viewModel);
        }

        public async Task<IActionResult> PrintLaborStandardsSprOperationNorma(string printTitle)
        {
            var sprOper = await _context.Sproper.ToListAsync();
            var sprDet = await _context.SprDet.ToListAsync();

            ViewData["PrintTitle"] = printTitle;

            var viewModel = new CombinedViewModelSprOperation
            {
                SprDetList = sprDet,
                SprOperList = sprOper
            };

            return View(viewModel);
        }

        public async Task<IActionResult> PrintTabel_RV_SZ(string printTitle)
        {
            var table = await _context.Tabel.ToListAsync();

            ViewData["PrintTitle"] = printTitle;

            return View();
        }

        public async Task<IActionResult> Reference_For_BOTiZ_By_Profession(string printTitle)
        {
            ViewData["PrintTitle"] = printTitle;

            return View();
        }
    }
}

