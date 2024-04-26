using Microsoft.AspNetCore.Identity;

namespace NardSmena.Models
{
    public class User : IdentityUser
    {
        public string FIO { get; set; }
        public string Department { get; set; }
    }
}
