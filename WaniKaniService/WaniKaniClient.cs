namespace WaniKaniService;

public class WaniKaniClient
{
    public WaniKaniClient(string token, string uriBase = DefaultApiUriBase)
    {
        Token = token;

        client.BaseAddress = new(uriBase);

        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

        UserClient = new UserClient(client);
    }

    private const string DefaultApiUriBase = "https://api.wanikani.com/v2/";

    private readonly HttpClient client = new HttpClient();

    public IResponseClient<User> UserClient { get; }

    private string Token { get; init; }

    public void UpdateBaseAddress(Uri uri)
    {
        client.BaseAddress = uri;
    }
}