using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NardSmena.Models
{
    [PrimaryKeyAttribute("NPP")]
    public class SPRMETAL
    {
        [Key]
        public int NPP { get; set; }

        public string? GR { get; set; }
        public string? PODGR { get; set; }
        public string? KMAT { get; set; }
        public string? PNMAT { get; set; }
        public double UDVES { get; set; }
        public string? NMAT { get; set; }
        public string? EIZ { get; set; }
        public string? RAZMER { get; set; }
        public string? GOST { get; set; }
        public string? HAR { get; set; }
        public string? KODTN { get; set; }
        public byte? VNORMA { get; set; }
    }
}
