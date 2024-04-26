using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NardSmena.Models
{
    [PrimaryKeyAttribute("ExtNom")]
    public class Nard
    {
        [Key]
        public int ExtNom { get; set; }

        public byte Selected { get; set; }
        public short Moon { get; set; }
        public int TabNomer { get; set; }
        public string? NameNariada { get; set; }
        public double SumAll { get; set; }
        public double TimeAll { get; set; }
        public short KodOpl { get; set; }

        [ForeignKey("TabNomer")]
        public SPRRAB SPRRAB { get; set; }
    }
}
