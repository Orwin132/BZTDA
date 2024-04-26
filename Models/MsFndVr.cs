using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NardSmena.Models
{
    [PrimaryKeyAttribute("PN")]
    public class MsFndVr
    {
        [Key]
        public int PN { get; set; }

        public short Mesec { get; set; }
        public string? NaimMes { get; set; }
        public int MFVrem { get; set; }
    }
}
