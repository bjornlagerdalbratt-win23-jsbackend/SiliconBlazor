using System.ComponentModel.DataAnnotations;

namespace SiliconBlazor.Models;

public class SubscriberNotificationsModel
{
    [Required(ErrorMessage = "Enter a valid email address")]
    [Display(Name = "Email address", Prompt = "Enter your email address", Order = 2)]
    [DataType(DataType.EmailAddress)]
    [RegularExpression("^(([^<>()\\[\\]\\\\.,;:\\s@\"]+(\\.[^<>()\\[\\]\\\\.,;:\\s@\"]+)*)|(\".+\"))@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$", ErrorMessage = "Invalid e-mail address")]
    public string Email { get; set; } = null!;
    public bool DailyNewsletter { get; set; } = true;
    public bool AdvertisingUpdates { get; set; } = true;
    public bool WeekInReview { get; set; } = true;
    public bool EventUpdates { get; set; } = true;
    public bool StartupsWeekly { get; set; } = true;
    public bool Podcasts { get; set; } = true;

    public bool checkboxNewsletter { get; set; }
}
