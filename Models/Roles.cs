using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace NardSmena.Models
{
    public class Roles : IdentityRole<int>
    {
        [Key]
        public int RoleId { get; set; }

        public string RoleName { get; set ;  }
    }
}
