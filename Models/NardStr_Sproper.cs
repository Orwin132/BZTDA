using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NardSmena.Models
{
    public class NardStr_Sproper
    {
        [Key]
        public int NardStr_SproperID { get; set; }

        public int NardStr_NomStr { get; set; }
        public int Sproper_NomStr { get; set; }

        [ForeignKey("NardStr_NomStr")]
        public NardStr NardStr { get; set; }
        [ForeignKey("Sproper_NomStr")]
        public Sproper Sproper { get; set; } 
    }
}
