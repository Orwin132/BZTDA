using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NardSmena.Models
{
    public class RoleAssignmentViewModel
    {
        [Key]
        public int RoleAssignmentId { get; set; }
        [ForeignKey("Id")]
        public string UserId { get; set; }
        public string SelectedRole { get; set; }
        public string FIO { get; set; }
        public string Department { get; set; }
    }
}
