using System.Text.Json.Serialization;

namespace WaniKaniService.Models;

public class Assignment
{
    [JsonPropertyName("available_at")]
    public DateTimeOffset? AvailableAt { get; set; }

    [JsonPropertyName("burned_at")]
    public DateTimeOffset? BurnedAt { get; set; }

    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("hidden")]
    public bool Hidden { get; set; }

    [JsonPropertyName("passed_at")]
    public DateTimeOffset? PassedAt { get; set; }

    [JsonPropertyName("resurrected_at")]
    public DateTimeOffset? ResurrectedAt { get; set; }

    [JsonPropertyName("srs_stage")]
    public int SrsStage { get; set; }

    [JsonPropertyName("started_at")]
    public DateTimeOffset? StartedAt { get; set; }

    [JsonPropertyName("subject_id")]
    public int SubjectId { get; set; }

    [JsonPropertyName("subject_type")]
    public SubjectType SubjectType { get; set; }

    [JsonPropertyName("unlocked_at")]
    public DateTimeOffset? UnlockedAt { get; set; }
}