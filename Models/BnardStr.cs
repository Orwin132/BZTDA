﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NardSmena.Models
{
    [PrimaryKeyAttribute("NomStr")]
    public class BnardStr
    {
        [Key]
        public int NomStr { get; set; }

        public string? KodiOperation { get; set; }
        public double Count { get; set; }
        public double Rascenka { get; set; }
        public double Time { get; set; }
        public short Day { get; set; }
        public DateTime Days { get; set; }

        public int ExtNom { get; set; }
        public string? ShifrDetal { get; set; }

        [ForeignKey("ExtNom")]
        public Bnard Bnard { get; set; }
        [ForeignKey("ShifrDetal")]
        public ShifrDet ShifrDet { get; set; }

    }
}
