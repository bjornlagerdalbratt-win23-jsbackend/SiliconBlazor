namespace SiliconBlazor.ViewModels;

public class ProfileInfoViewModel
{
    public string UserProfileId { get; set; } = null!;
    public string? ProfileImage { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Bio { get; set; }
    public string? PhoneNumber { get; set; }

    public AddressViewModel? Address { get; set; }
}
