using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NardSmena.Models
{
    [PrimaryKeyAttribute("ExtNom")]
    public class UchDet
    {
        [Key]
        public int ExtNom { get; set; }

        public int NomStr { get; set; }
        public short KodOperation { get; set; }
        public string? NameOperation { get; set; }
        public string? KodDetal { get; set; }
        public string? NameDetal { get; set; }
        public double Count { get; set; }
        public int TabNomer { get; set; }
        public short KodOpl { get; set; }
        public short Moon { get; set; }
        public short Day { get; set; }
        public DateTime Days { get; set; }
        public string? FIO { get; set; }
        public short Uch { get; set; }
        public short Ceh { get; set; }

        [ForeignKey("NomStr")]
        public NardStr NardStr { get; set ; }
        [ForeignKey("KodDetal")]
        public SprDet SprDet { get; set; }
    }
}
