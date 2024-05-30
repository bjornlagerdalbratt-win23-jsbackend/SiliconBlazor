namespace SiliconBlazor.Models;

public class GraphQLResponse<T>
{
    public T Data { get; set; } = default!;
}
