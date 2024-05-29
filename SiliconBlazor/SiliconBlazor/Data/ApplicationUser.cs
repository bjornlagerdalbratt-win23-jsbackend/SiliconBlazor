using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SiliconBlazor.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    public string? Bio { get; set; }
    public string? ProfileImage { get; set; } = "avatar.png";


    //public string? UserProfileId { get; set; }
    //public UserProfile? UserProfile { get; set; }
    public string? UserAddressId { get; set; }
    public UserAddress? Address { get; set; }

}
