using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NardSmena.Models
{
    [PrimaryKeyAttribute("KodProf")]
    public class PROFF
    {
        [Key]
        public short KodProf { get; set; }

        public string? NameProf { get; set; }
    }
}
