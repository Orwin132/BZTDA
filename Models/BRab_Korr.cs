using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NardSmena.Models
{
    [PrimaryKeyAttribute("NomStr")]
    public class BRab_Korr
    {
        [Key]
        public int NomStr { get; set; }

        public int ExtNom { get; set; }
        public short NNariada { get; set; }
        public short Moon { get; set; }
        public int TabNomer { get; set; }
        public double KTU { get; set; }
        public double SumAll { get; set; }
        public double TimeAll { get; set; }
        public short KodOpl { get; set; }

        public int TabelId { get; set; }

        [ForeignKey("ExtNom")]
        public Tabel Tabel { get; set; }
    }
}
