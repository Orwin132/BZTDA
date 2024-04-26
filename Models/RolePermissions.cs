using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NardSmena.Models
{
    [PrimaryKeyAttribute("RolePermissionId")]
    public class RolePermissions
    {
        public int RolePermissionId { get ;  set; }
        public int RoleId { get; set ; }
        public int PermissionId { get; set; }

        [ForeignKey("RoleId")]
        public Roles Roles { get; set; }
        [ForeignKey("PermissionId")]
        public Permissions Permissions { get; set; }
    }
}
