namespace SiliconBlazor.Models;

public class FullCourseModel
{
    public string? Id { get; set; }
    public string? ImageUri { get; set; }
    public string? ImageHeaderUri { get; set; }
    public string? ImageAuthor { get; set; }
    public bool IsBestSeller { get; set; }
    public bool IsDigital { get; set; }
    public string Title { get; set; } = null!;
    public string? Ingress { get; set; }
    public decimal StarRating { get; set; }
    public string? Reviews { get; set; }
    public List<Author>? Authors { get; set; }
    public string? Article { get; set; }
    public string? Resource { get; set; }
    public bool? Access { get; set; }
    public bool? Certificate { get; set; }
    public string? Price { get; set; }
    public string? DiscountPrice { get; set; }
    public string? Currency { get; set; }

    public string? Content { get; set; }
    public string? Hours { get; set; }
    public string? LikesInNumers { get; set; }
    public string? LikesInProcent { get; set; }
    public string? Description { get; set; }

}
