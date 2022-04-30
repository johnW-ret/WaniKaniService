using System.Text.Json.Serialization;

namespace WaniKaniService.Models;

public abstract class Subject
{
    public abstract SubjectType Type { get; }

    [JsonPropertyName("auxiliary_meanings")]
    public List<AuxiliaryMeaning> AuxiliaryMeanings { get; set; } = new List<AuxiliaryMeaning>();

    [JsonPropertyName("characters")]
    public string Characters { get; set; } = null!;

    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("document_url")]
    public Uri DocumentUrl { get; set; } = null!;

    [JsonPropertyName("hidden_at")]
    public DateTimeOffset? HiddenAt { get; set; }

    [JsonPropertyName("lesson_position")]
    public int LessonPosition { get; set; }

    [JsonPropertyName("level")]
    public int Level { get; set; }

    [JsonPropertyName("meaning_mnemonic")]
    public string MeaningMnemonic { get; set; } = null!;

    [JsonPropertyName("meanings")]
    public List<Meaning> Meanings { get; set; } = new List<Meaning>();

    [JsonPropertyName("slug")]
    public string Slug { get; set; } = null!;

    [JsonPropertyName("spaced_repetition_system_id")]
    public int SpacedRepetitionSystemId { get; set; }
}