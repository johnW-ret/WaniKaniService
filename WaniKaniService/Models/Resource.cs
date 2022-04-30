using System.Text.Json.Serialization;

namespace WaniKaniService.Models;

[JsonConverter(typeof(Json.ResourceSubjectConverter))]
public class Resource<T> : Response<T>
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}