using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NardSmena.Models
{
    [PrimaryKeyAttribute("NomStr")]
    public class Sproper
    {
        [Key]
        public int NomStr { get; set; }

        public string? KodDetal { get; set; }
        public short FlagObhoda { get; set; }
        public short KodOperation { get; set; }
        public string? NameOperation { get; set; }
        public short Razriad { get; set; }
        public double TimeComput { get; set; }
        public double TimeOperation { get; set; }
        public double Vrednost { get; set; }
        public double Procent { get; set; }
        public double Rascenka { get; set; }
        public short GrTarif { get; set; }
        public short DpPrem { get; set; }
        public double KoefDV { get; set; }

        [ForeignKey("KodDetal")]
        public SprDet SprDet { get; set; }
        [ForeignKey("Razriad")]
        public TARIF TARIF { get; set; }
    }
}
