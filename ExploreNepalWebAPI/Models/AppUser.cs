using Microsoft.AspNetCore.Identity;

namespace IdentityFour.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
