using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NardSmena.Models
{
    [PrimaryKeyAttribute("Empty")]
    public class Kerna
    {
        [Key]
        public int Empty { get; set; }

        public int TabNomer { get; set; }
        public short KodOpl { get; set; }
        public string? KodDetal { get; set; }
        public short KodOperation { get; set; }
        public string? NameDetal { get; set; }
        public string? NameOperation { get; set; }
        public double Count { get; set; }
        public short Moon { get; set; }
        public DateTime Days { get; set; }
        public string? FIO { get; set; }
        public short Uch { get; set; }

        [ForeignKey("TabNomer")]
        public SPRRAB SPRRAB { get; set; }
        [ForeignKey("KodDetal")]
        public SprDet SprDet { get; set; }
    }
}
