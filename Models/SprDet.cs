using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NardSmena.Models
{
    [PrimaryKeyAttribute("KodDetal")]
    public class SprDet
    {
        [Key]
        public string? KodDetal { get; set; }

        public string? NameDetal { get; set; }
        public string? ShifrDetal { get; set; }
        public bool Selected { get; set; }
        public short PrDopPrem { get; set; }
    }
}
