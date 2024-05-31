using System.ComponentModel.DataAnnotations;

namespace SiliconBlazor.ViewModels;

public class SubscribeViewModel
{
    [EmailAddress]
    [Required(ErrorMessage = "You must provide an email address")]
    [Display(Name = "Email address", Prompt = "Your Email")]
    public string Email { get; set; } = null!;
    public bool DailyNewsletter { get; set; }
    public bool AdvertisingUpdates { get; set; }
    public bool WeekInReview { get; set; }
    public bool EventUpdates { get; set; }
    public bool StartupsWeekly { get; set; }
    public bool Podcasts { get; set; }

    //for account notifications page
    public bool checkboxNewsletter { get; set; } = false;
}
