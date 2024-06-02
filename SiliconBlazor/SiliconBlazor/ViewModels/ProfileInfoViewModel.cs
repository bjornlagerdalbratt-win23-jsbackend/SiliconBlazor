using System.ComponentModel.DataAnnotations;

namespace SiliconBlazor.ViewModels;

public class ProfileInfoViewModel
{
    public string UserProfileId { get; set; } = null!;
    public string? ProfileImage { get; set; }

    [Display(Name = "First Name", Prompt = "Enter your first name", Order = 0)]
    [Required(ErrorMessage = "First name is required")]
    [DataType(DataType.Text)]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last Name", Prompt = "Enter your last name", Order = 1)]
    [Required(ErrorMessage = "Last name is required")]
    [DataType(DataType.Text)]
    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    [Display(Name = "Bio", Prompt = "Add a short bio...", Order = 4)]
    [DataType(DataType.MultilineText)]
    public string? Bio { get; set; }

    [Display(Name = "Phone", Prompt = "Enter your phone", Order = 3)]
    [DataType(DataType.PhoneNumber)]
    [Required(ErrorMessage = "Phone number not correct format")]
    public string? PhoneNumber { get; set; }

    public AddressViewModel? Address { get; set; }
}
