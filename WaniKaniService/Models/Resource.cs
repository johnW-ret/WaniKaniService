using System.Text.Json.Serialization;

namespace WaniKaniService.Models;

public class Resource<T> : Response<T>
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}