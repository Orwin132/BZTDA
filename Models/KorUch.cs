using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NardSmena.Models
{
    [PrimaryKeyAttribute("ExtNom")]
    public class KorUch
    {
        [Key]
        public int ExtNom { get; set; }

        public int TabNomer { get; set; }
        public short KodOpl { get; set; }
        public string? KodDetal { get; set; }
        public short KodOperation { get; set; }
        public string? NameDetal { get; set; }
        public double Count_old { get; set; }
        public double CountN { get; set; }
        public double Raznica { get; set; }
        public DateTime Days { get; set; }
        public DateTime SysDat { get; set; }
        public short Moon { get; set; }
        public string? Komment { get; set; }

        [ForeignKey("TabNomer")]
        public SPRRAB SPRRAB { get; set; }
        [ForeignKey("KodDetal")]
        public SprDet SprDet { get; set; }
    }
}
