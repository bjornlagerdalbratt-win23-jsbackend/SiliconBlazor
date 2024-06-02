using System.ComponentModel.DataAnnotations;

namespace SiliconBlazor.Models;

public class SubscriberNotificationsModel
{
    [Required]
    public string Email { get; set; } = null!;
    public bool DailyNewsletter { get; set; } = true;
    public bool AdvertisingUpdates { get; set; } = true;
    public bool WeekInReview { get; set; } = true;
    public bool EventUpdates { get; set; } = true;
    public bool StartupsWeekly { get; set; } = true;
    public bool Podcasts { get; set; } = true;

    public bool checkboxNewsletter { get; set; }
}
