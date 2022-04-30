using System.Text.Json.Serialization;

namespace WaniKaniService.Models;

public class Kanji : Subject
{
    public override SubjectType Type => SubjectType.Kanji;

    [JsonPropertyName("amalgamation_subject_ids")]
    public List<int> AmalgamationSubjectIds { get; set; } = new List<int>();

    [JsonPropertyName("component_subject_ids")]
    public List<int> ComponentSubjectIds { get; set; } = new List<int>();

    [JsonPropertyName("meaning_hint")]
    public string? MeaningHint { get; set; } = null!;

    [JsonPropertyName("reading_hint")]
    public string? ReadingHint { get; set; } = null!;

    [JsonPropertyName("reading_mnemonic")]
    public string ReadingMnemonic { get; set; } = null!;

    [JsonPropertyName("readings")]
    public List<Reading> Readings { get; set; } = new List<Reading>();

    [JsonPropertyName("visually_similar_subject_ids")]
    public List<int> VisuallySimilarSubjectIds { get; set; } = new List<int>();
}