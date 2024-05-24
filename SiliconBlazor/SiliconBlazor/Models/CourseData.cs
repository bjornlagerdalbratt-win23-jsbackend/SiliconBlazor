namespace SiliconBlazor.Models;

public class CourseData
{
    public string Id { get; set; } = null!;
    public bool IsBestSeller { get; set; }
    public string? Title { get; set; }

    public string? ImageUri { get; set; }
    public List<Author>? Authors { get; set; }
    public PriceData? Prices { get; set; }
    public string? Hours { get; set; }
    public string? LikesInProcent { get; set; }
    public string? Likes { get; set; }
}

public class Author
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}

public class PriceData
{
    public string? Currency { get; set; }
    public double Price { get; set; }
    public double Discount { get; set; }
}