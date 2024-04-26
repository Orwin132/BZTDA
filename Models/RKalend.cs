using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NardSmena.Models
{
    [PrimaryKeyAttribute("Npp")]
    public class RKalend
    {
        [Key]
        public int Npp { get; set; }

        public DateTime DataR { get; set; }
    }
}
