using System.Text.Json.Serialization;

namespace WaniKaniService.Models;

public class CollectionPageData
{
    [JsonPropertyName("next_url")]
    public Uri? NextUrl { get; set; }

    [JsonPropertyName("previous_url")]
    public Uri? PreviousUrl { get; set; }

    [JsonPropertyName("per_page")]
    public int PerPage { get; set; }
}