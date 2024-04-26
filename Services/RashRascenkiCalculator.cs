using Microsoft.EntityFrameworkCore;
using NardSmena.Models;

namespace NardSmena.Services
{
    public class RashRascenkiCalculator
    {
        private readonly ApplicationContext _context;

        public RashRascenkiCalculator (ApplicationContext context)
        {
            _context = context;
        }


        public async void Task<CalculateRashRascenki> ()
        {
            var tarif = await _context.TARIF.FirstAsync();
            var sprOper = await _context.Sproper.FirstOrDefaultAsync();

            if (sprOper != null)
            {
                if (sprOper.NameOperation != null)
                {
                    if (sprOper.NameOperation.Contains("слесарная"))
                    {
                        sprOper.NameOperation = "слесарная";
                    }
                    else if (sprOper.NameOperation.Contains("фрезерная"))
                    {
                        sprOper.NameOperation = "фрезерная";
                    }
                    else if (sprOper.NameOperation.Contains("шлифовальная"))
                    {
                        sprOper.NameOperation = "шлифовальная";
                    }
                    else if (sprOper.NameOperation.Contains("автоматическая"))
                    {
                        sprOper.NameOperation = "автоматическая";
                    }
                    else if (sprOper.NameOperation.Contains("токарная"))
                    {
                        sprOper.NameOperation = "токарная";
                    }
                    else if (sprOper.NameOperation.Contains("сверлильная"))
                    {
                        sprOper.NameOperation = "сверлильная";
                    }

                    double TR;

                    switch (sprOper.GrTarif)
                    {
                        case 1:
                            TR = tarif.Tarif1;
                            break;
                        case 2:
                            TR = tarif.Tarif;
                            break;
                        case 3:
                            TR = tarif.Tarif3;
                            break;
                        default:
                            TR = 0;
                            break;
                    }

                    if (sprOper.Procent == null)
                    {
                        sprOper.Rascenka = Okrug(( sprOper.TimeOperation * TR ) / 60);
                    }
                    else
                    {
                        sprOper.Rascenka = Okrug(( sprOper.TimeOperation * TR * ( 1 + sprOper.Procent  / 100 )) / 60 );
                    }

                    if (sprOper.Rascenka < 0.001 && sprOper.TimeOperation > 0)
                    {
                        sprOper.Rascenka = 0.001f;
                    }

                   await _context.SaveChangesAsync();
                }
            }
        }

        private double Okrug(double value)
        {
            return (double) Math.Round(value, 3);
        }
    }
}
