using System.Text.Json.Serialization;

namespace WaniKaniService.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SubjectType
{
    Radical,
    Kanji,
    Vocabulary
}