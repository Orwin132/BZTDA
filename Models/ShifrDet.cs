using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NardSmena.Models
{
    [PrimaryKeyAttribute("ShifrDetal")]
    public class ShifrDet
    {
        [Key]
        public string ShifrDetal { get; set;}

        public string KodDetal { get; set; }

        [ForeignKey("KodDetal")]
        public SprDet SprDet { get; set; }
    }
}
