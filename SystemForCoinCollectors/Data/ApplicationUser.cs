using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SystemForCoinCollectors.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [StringLength(30)]
        public string? Name { get; set; }
        
        [StringLength(30)]
        public string? Surname { get; set; }
        
        [StringLength(50)]
        public string? Address { get; set; }
    }

}
