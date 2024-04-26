using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NardSmena.Models
{
    [PrimaryKeyAttribute("TabNomer")]
    public class SPRRAB
    {
        [Key]
        public int TabNomer { get; set; }

        public short Ceh { get; set; }
        public short Uch { get; set; }
        public string? FIO { get; set; }
        public short KodProfessii { get; set; }
        public short Kategoria { get; set; }

        [ForeignKey("KodProfessii")]
        public PROFF PROFF { get; set; }
    }
}
