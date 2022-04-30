using System.Text.Json.Serialization;

namespace WaniKaniService.Models;

public class Meaning
{
    [JsonPropertyName("meaning")]
    public string? EnglishMeaning { get; set; }

    [JsonPropertyName("primary")]
    public bool Primary { get; set; }

    [JsonPropertyName("accepted_answer")]
    public bool AcceptedAnswer { get; set; }
}