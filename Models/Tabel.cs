using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NardSmena.Models
{
    [PrimaryKeyAttribute("ExtNom")]
    public class Tabel
    {
        [Key]
        public int ExtNom { get; set; }

        public short Moon { get; set; }
        public int TabNomer { get; set; }
        public short TimeFact { get; set; }
        public short NormoVremia { get; set; }
        public double SumAll { get; set; }
        public double PrVip { get; set; }
        public short KodOpl { get; set; }

        [ForeignKey("TabNomer")]
        public SPRRAB SPRRAB { get; set; }
    }
}
