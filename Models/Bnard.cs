using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NardSmena.Models
{
    [PrimaryKeyAttribute("ExtNom")]
    public class Bnard
    {
        [Key]
        public int ExtNom { get; set; }

        public short Moon { get; set; }
        public byte Selected { get; set; }
        public short NNariada { get; set; }
        public string? NameNariada { get; set; }
        public double SummAll { get; set; }
        public double TimeAll { get; set; }
        public short KodOpl { get; set; }
    }
}
