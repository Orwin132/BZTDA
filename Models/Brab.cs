using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NardSmena.Models
{
    [PrimaryKeyAttribute("NomStr")]
    public class Brab
    {
        [Key]
        public int NomStr { get; set; }

        public int ExtNom { get; set; }
        public int TabNomer { get; set; }
        public double KTU { get; set; }
        public double SumAll { get; set; }
        public double TimeAll { get; set; }
        public short KodOpl { get; set; }

        [ForeignKey("ExtNom")]
        public Bnard Bnard { get; set; }
        [ForeignKey("TabNomer")]
        public SPRRAB SPRRAB { get; set; }
    }
}
