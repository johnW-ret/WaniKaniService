using System.Text.Json.Serialization;

namespace WaniKaniService.Models;

public class Reading
{
    [JsonPropertyName("reading")]
    public string? KanaReading { get; set; }

    [JsonPropertyName("priority")]
    public bool Priority { get; set; }

    [JsonPropertyName("accepted_answer")]
    public bool AcceptedAnswer { get; set; }

    [JsonPropertyName("type")]
    public ReadingType Type { get; set; }
}