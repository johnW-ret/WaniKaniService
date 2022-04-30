using System.Text.Json.Serialization;

namespace WaniKaniService.Models;

public class CollectionResponse<T> : Response<List<Resource<T>>>
{
    [JsonPropertyName("pages")]
    public CollectionPageData Pages { get; set; } = null!;

    [JsonPropertyName("total_count")]
    public int TotalCount { get; set; }
}