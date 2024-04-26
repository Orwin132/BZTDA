using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NardSmena.Models
{
    public class BnardStr_Sproper
    {
        [Key]
        public int BnardStr_SproperID { get; set; }

        public int BnardStr_NomStr { get; set; }
        public int Sproper_NomStr { get; set; }

        [ForeignKey("BnardStr_NomStr")]
        public BnardStr BnardStr { get; set; }
        [ForeignKey("Sproper_NomStr")]
        public Sproper Sproper { get; set; }
    }
}
