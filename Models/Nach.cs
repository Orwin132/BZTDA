using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NardSmena.Models
{
    public class Nach
    {
        [Key]
        public string POB { get; set; }

        public double TAB { get; set; }
        public double KOD { get; set; }
        public string? DATEOPL { get; set; }
        public double TIMEOPL { get; set; }
        public double SUMMA { get; set; }
    }
}
