using System.Text.Json.Serialization;

namespace WaniKaniService.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ReadingType
{
    Kunyomi,
    Nanori,
    Onyomi
}