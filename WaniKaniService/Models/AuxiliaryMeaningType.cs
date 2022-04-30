using System.Text.Json.Serialization;

namespace WaniKaniService.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AuxiliaryMeaningType
{
    Whitelist,
    Blacklist
}