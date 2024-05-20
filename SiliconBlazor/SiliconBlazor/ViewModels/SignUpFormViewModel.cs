using System.ComponentModel.DataAnnotations;

namespace SiliconBlazor.ViewModels;

public class SignUpFormViewModel
{
    [Required(ErrorMessage = "Enter your first name")]
    [DataType(DataType.Text)]
    [Display(Name = "First name", Prompt = "Enter your first name", Order = 0)]
    [MinLength(2, ErrorMessage = "Enter your first name")]
    public string FirstName { get; set; } = null!;


    [Required(ErrorMessage = "Enter your last name")]
    [DataType(DataType.Text)]
    [Display(Name = "Last name", Prompt = "Enter your last name", Order = 1)]
    [MinLength(2, ErrorMessage = "Enter your last name")]
    public string LastName { get; set; } = null!;


    [Required(ErrorMessage = "Enter a valid email address")]
    [Display(Name = "Email address", Prompt = "Enter your email address", Order = 2)]
    [DataType(DataType.EmailAddress)]
    [RegularExpression("^(([^<>()\\[\\]\\\\.,;:\\s@\"]+(\\.[^<>()\\[\\]\\\\.,;:\\s@\"]+)*)|(\".+\"))@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$", ErrorMessage = "Invalid e-mail address")]
    public string Email { get; set; } = null!;


    [Required(ErrorMessage = "Enter a valid password")]
    [Display(Name = "Password", Prompt = "Enter your password", Order = 3)]
    [DataType(DataType.Password)]
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Enter a valid password")]
    public string Password { get; set; } = null!;


    [Required(ErrorMessage = "Password must be confirmed")]
    [Display(Name = "Confirm password", Prompt = "Confirm your passwrod", Order = 4)]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Password must be confirmed")]
    public string ConfirmPassword { get; set; } = null!;


    [Display(Name = "I agree to Terms & Conditions ", Prompt = "Terms and Conditions", Order = 5)]
    public bool TermsAndCondition { get; set; } = false;
}

