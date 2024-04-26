using Microsoft.EntityFrameworkCore;
using NardSmena.Interfaces;
using NardSmena.Models;

namespace NardSmena.Services
{
    public class DataCopyServices : ICopyDataService
    {
        private readonly ApplicationContext _context;
        private readonly IWebHostEnvironment _environment;

        public DataCopyServices(ApplicationContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public void CopyData(int month)
        {
            try
            {
                _context.UchDet.RemoveRange(_context.UchDet);
                _context.SaveChanges();

                var query = @"
    SELECT DISTINCT
        Uchdet_new.TabNomer,
        Uchdet_new.KodDetal,
        Uchdet_new.KodOperation,
        Uchdet_new.KodOpl,
        Uchdet_new.Uch,
        Uchdet_new.NameDetal,
        Uchdet_new.""Count"",
        Uchdet_new.Moon,
        Uchdet_new.TimeOperation,
        Uchdet_new.Rascenka,
        SprOper.Vrednost,
        SprOper.DpPrem,
        Sprrab.Ceh,
        Sprrab.FIO,
        Nard.Selected,
        Proff.NameProf,
        (Uchdet_new.TimeOperation * Uchdet_new.""Count"") / 60 as Vrem,
        Uchdet_new.Rascenka * Uchdet_new.""Count"" as Summa,
        SprDet.PrDopPrem
    FROM
        ""UchDet_New.DB"" Uchdet_new
    INNER JOIN
        ""SPRRAB.DB"" Sprrab ON (Uchdet_new.TabNomer = Sprrab.TabNomer)
    INNER JOIN
        ""Nard.DB"" Nard ON (Uchdet_new.TabNomer = Nard.TabNomer)
    INNER JOIN
        ""PROFF.DB"" Proff ON (Sprrab.KodProfessii = Proff.KodProf)
    INNER JOIN
        ""SprOper.db"" SprOper ON (Uchdet_new.KodDetal = SprOper.KodDetal AND Uchdet_new.KodOperation = SprOper.KodOperation)
    INNER JOIN
        ""SprDet.db"" SprDet ON (SprOper.KodDetal = SprDet.KodDetal)
    WHERE
        (Nard.Moon = :ms)
        AND (Nard.Selected = TRUE)
    ORDER BY
        Uchdet_new.Uch,
        Uchdet_new.TabNomer,
        Uchdet_new.KodOpl,
        Uchdet_new.KodDetal,
        Uchdet_new.KodOperation;
";
                var parameters = new { ms = month };

                _context.Database.ExecuteSqlRaw(query, parameters);

                string ishFile = Path.Combine(_environment.WebRootPath, "uploads");
                string datFile = Path.Combine(ishFile, $"OtlKchP_{Convert.ToInt64(DateTime.Now.ToShortDateString())}" + ".db");

                System.IO.File.Copy(ishFile, datFile, true);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred: {ex.Message}");
            }
        }
    }
}
