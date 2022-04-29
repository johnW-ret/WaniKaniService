using System.Text.Json;

namespace WaniKaniService;

public abstract class Client
{
    public Client(HttpClient client)
    {
        httpClient = client;
        httpClient.DefaultRequestHeaders.Accept.Clear();
    }

    private HttpClient httpClient { get; init; }

    protected abstract string ResponseName { get; }

    protected async Task<R> GetResponse<R>(string uriExtension)
        where R : class
    {
        Task<Stream> streamTask = httpClient.GetStreamAsync(uriExtension);

        R? response = null;

        try
        {
            response = await JsonSerializer.DeserializeAsync<R>(await streamTask);
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
