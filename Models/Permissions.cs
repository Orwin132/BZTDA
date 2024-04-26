using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NardSmena.Models
{
    [PrimaryKeyAttribute("PermissionId")]
    public class Permissions
    {
        public int PermissionId { get; set; }
        public string PermissionName { get ;  set; }
    }
}
