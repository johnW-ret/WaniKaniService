using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using WaniKaniService.Models;

namespace WaniKaniService.Json;

public class ResourceSubjectConverter : JsonConverter<Resource<Subject>>
{
    public override Resource<Subject> Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        // get document
        JsonDocument document = JsonDocument.ParseValue(ref reader);

        // check for object property to because we need it as type discrminator
        if (!document.RootElement.TryGetProperty("object", out JsonElement objectElement))
            throw new JsonException("Response object has invalid formatting");

        // switch type sting to Type
        string objectTypeString = objectElement.GetString()!;
        Type type = objectTypeString switch
        {
            "radical" => throw new JsonException("Unsupported object"),
            "kanji" => typeof(Kanji),
            "vocabulary" => throw new JsonException("Unsupported object"),
            _ => throw new JsonException("Unsupported object")
        };

        // get the data property
        if (document.RootElement.TryGetProperty("data", out JsonElement dataElement))
        {
            // deserialize as Subject and cast
            Subject data = (Subject)dataElement.Deserialize(type)!;

            // return new Resource with Data derived type
            return new Resource<Subject>()
            {
                Id = document.RootElement.GetProperty("id").GetInt32(),
                Data = data,
                DataUpdatedAt = document.RootElement.GetProperty("data_updated_at").GetDateTimeOffset(),
                Object = objectTypeString,
                Url = new(document.RootElement.GetProperty("url").GetString()!)
            };
        }
        else
            throw new JsonException("Response object missing 'data' property");
    }

    public override void Write(
        Utf8JsonWriter writer,
        Resource<Subject> value,
        JsonSerializerOptions options)
    {
        throw new NotSupportedException();
    }
}