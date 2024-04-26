using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NardSmena.Models
{
    [PrimaryKeyAttribute("Id")]
    public class Sravnenie
    {
        [Key]
        public int Id { get; set ;  }

        public string? KodDetal { get; set; }
        public short KodOperation { get; set; }
        public short Razriad { get; set; }
        public short Razriad_1 { get; set; }
        public short GrTarif { get; set; }
        public short GrTarif_1 { get; set; }
        public double Vrednost { get; set; }
        public double Vrednost_1 { get; set; }
        public double TimeOperation { get; set; }
        public double TimeOperation_1 { get; set; }
        public double Rascenka { get; set; }
        public double Rascenka_1 { get; set; }

        [ForeignKey("KodDetal")]
        public SprDet SprDet { get; set ;  }
        [ForeignKey("Razriad")]
        public TARIF TARIF { get; set; }
    }
}
