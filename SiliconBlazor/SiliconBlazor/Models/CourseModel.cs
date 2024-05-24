namespace SiliconBlazor.Models;

public class CourseModel
{
    public int Id { get; set; }
    public string? ImageUri { get; set; }
    public string? ImageHeaderUri { get; set; }
    public bool IsBestSeller { get; set; }
    public string? Image { get; set; }
    public string Title { get; set; } = null!;
    public string? Author { get; set; }
    public string? Price { get; set; }
    public string? DiscountPrice { get; set; }
    public string? Hours { get; set; }
    public string? LikesInNumers { get; set; }
    public string? LikesInProcent { get; set; }
}

