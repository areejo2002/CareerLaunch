using Microsoft.AspNetCore.Identity;

namespace CareerLaunchpad.Models
{
    public class Person:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
