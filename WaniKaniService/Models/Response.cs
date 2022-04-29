namespace WaniKaniService;

using System.Text.Json.Serialization;

public class Response<T>
{
    [JsonPropertyName("object")]
    public string Object { get; set; } = null!;

    [JsonPropertyName("url")]
    public Uri Url { get; set; } = null!;

    [JsonPropertyName("data_updated_at")]
    public DateTimeOffset? DataUpdatedAt { get; set; }

    [JsonPropertyName("data")]
    public T? Data { get; set; } = default!;
}