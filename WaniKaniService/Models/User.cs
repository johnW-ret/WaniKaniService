using System.Text.Json.Serialization;

namespace WaniKaniService;

public class User
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("current_vacation_started_at")]
    public DateTimeOffset? CurrentVacationStartedAt { get; set; }

    [JsonPropertyName("level")]
    public int Level { get; set; }

    [JsonPropertyName("preferences")]
    public Preferences Preferences { get; set; } = null!;

    [JsonPropertyName("profile_url")]
    public Uri? ProfileUrl { get; set; }

    [JsonPropertyName("started_at")]
    public DateTimeOffset? StartedAt { get; set; }

    [JsonPropertyName("subscription")]
    public Subscription Subscription { get; set; } = null!;

    [JsonPropertyName("username")]
    public string? Username { get; set; }
}