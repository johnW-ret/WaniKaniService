using System.Text.Json.Serialization;

namespace WaniKaniService.Models;

public class AuxiliaryMeaning
{
    [JsonPropertyName("meaning")]
    public string? EnglishMeaning { get; set; }

    [JsonPropertyName("type")]
    public AuxiliaryMeaningType Type { get; set; }
}