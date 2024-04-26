using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NardSmena.Models
{
    [PrimaryKeyAttribute("Razriad")]
    public class TARIF
    {
        [Key]
        public short Razriad { get; set; }

        public double Tarif1 { get; set; }
        public double Tarif { get; set; }
        public double Tarif3 { get; set; }
        public double MTarif { get; set; }
    }
}
