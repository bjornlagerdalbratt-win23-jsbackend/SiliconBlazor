namespace SiliconBlazor.Models;

public class CourseCardModel
{
    public string? Id { get; set; }
    public bool IsBestSeller { get; set; }
    public string? ImageAuthor { get; set; }
    public string? ImageUri { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Price { get; set; }
    public string? DiscountPrice { get; set; }
    public string? Hours { get; set; }
    public string? LikesInNumbers { get; set; }
    public string? LikesInProcent { get; set; }
    public List<string>? Categories { get; set; } // Lägg till denna rad
}
