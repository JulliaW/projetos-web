using Microsoft.AspNetCore.Identity;

namespace Carros.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }
    }
}
