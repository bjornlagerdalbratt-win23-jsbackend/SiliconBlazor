namespace SiliconBlazor.Models;

public class CourseData
{
    public string Id { get; set; } = null!;
    public bool IsBestSeller { get; set; }
    public bool IsDigital { get; set; }
    public string? Title { get; set; }
    public string? Ingress { get; set; }
    public decimal StarRating { get; set; }
    public string? Reviews { get; set; }
    public string? ImageHeaderUri { get; set; }

    public string? ImageUri { get; set; }
    public List<Author>? Authors { get; set; }
    public PriceData? Prices { get; set; }
    public ContentData? Content { get; set; }
    public string? Hours { get; set; }
    public string? LikesInProcent { get; set; }
    public string? Likes { get; set; }
    public string? Icon { get; set; }

    public List<string>? Categories { get; set; } // Lägg till denna rad
}

public class Author
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ImageUrl { get; set; }
}

public class PriceData
{
    public string? Currency { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}
public class ContentData
{
    public string? Description { get; set; }
    public string[]? Includes { get; set; }
    public virtual List<ProgramDetailItemData>? ProgramDetails { get; set; }
}
public class ProgramDetailItemData
{
    public int Number { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? IconClass { get; set; }
}
