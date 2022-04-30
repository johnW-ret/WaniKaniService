using System.Text.RegularExpressions;
using WaniKaniService.Models;

namespace WaniKaniService;

public class WaniKaniClient
{
    public WaniKaniClient(string token, string uriBase = DefaultApiUriBase)
    {
        if (token is null)
            throw new ArgumentException("API token is null.");
        else if (!Regex.IsMatch(token, WaniKaniApiKeyPattern))
            throw new ArgumentException("Invalid API token format.");

        Token = token;

        client.BaseAddress = new(uriBase);

        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

        UserClient = new UserClient(client);
        SubjectsClient = new SubjectsClient(client);
    }

    private const string DefaultApiUriBase = "https://api.wanikani.com/v2/";
    private const string WaniKaniApiKeyPattern = "^[a-z0-9]{8}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{12}$";

    private readonly HttpClient client = new HttpClient();

    public IResponseClient<User> UserClient { get; }
    public ICollectionClient<Subject> SubjectsClient { get; }

    private string Token { get; init; }

    public void UpdateBaseAddress(Uri uri)
    {
        client.BaseAddress = uri;
    }
}