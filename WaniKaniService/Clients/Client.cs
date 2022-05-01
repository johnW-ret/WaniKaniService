using System.Text.Json;
using WaniKaniService.Json;

namespace WaniKaniService;

public abstract class Client
{
    public Client(HttpClient client)
    {
        httpClient = client;
        httpClient.DefaultRequestHeaders.Accept.Clear();

        _options = new JsonSerializerOptions();
        _options.Converters.Add(new ResourceSubjectConverter());
    }

    private JsonSerializerOptions _options;

    private HttpClient httpClient { get; init; }

    protected abstract string ResponseName { get; }

    protected async Task<R> GetResponse<R>(string uriExtension)
        where R : class
    {
        Task<Stream> streamTask = httpClient.GetStreamAsync(uriExtension);

        R? response = null;

        try
        {
            response = await JsonSerializer.DeserializeAsync<R>(await streamTask, _options);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e.Message);
        }

        if (response == null)
            throw new NullReferenceException();

        return response;
    }
}
