using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NardSmena.Models
{
    [PrimaryKeyAttribute("PN")]
    public class OtpVred
    {
        [Key]
        public int PN { get; set; }

        public short ProcDopl { get; set; }
        public short GodOtpVr { get; set; }
    }
}
