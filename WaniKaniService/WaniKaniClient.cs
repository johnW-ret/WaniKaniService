using System.Text.RegularExpressions;
using WaniKaniService.Models;

namespace WaniKaniService;

public class WaniKaniClient
{
    public WaniKaniClient()
    {
        AssignmentsClient = new AssignmentsClient(client);
        UserClient = new UserClient(client);
        SubjectsClient = new SubjectsClient(client);
    }

    public WaniKaniClient(string token, string uriBase = DefaultApiUriBase) : this()
    {
        SetClientToken(token);
        SetClientBaseAddress(new(uriBase));
    }

    private const string DefaultApiUriBase = "https://api.wanikani.com/v2/";
    private const string WaniKaniApiKeyPattern = "^[a-z0-9]{8}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{12}$";

    private readonly HttpClient client = new HttpClient();

    public ICollectionClient<Assignment> AssignmentsClient { get; }
    public IResponseClient<User> UserClient { get; }
    public ICollectionClient<Subject> SubjectsClient { get; }

    private string? _token;
    /// <summary>
    /// The API key for the WaniKani user account we are making requests to.
    /// 
    /// This token may be <c>null</c> on construction for patterns like dependency injection, however, it may not be set to <c>null</c> at any other point in its lifetime.
    /// </summary>
    private string? Token
    { 
        get => _token;
        set
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value), "API token is null.");
            else if (!Regex.IsMatch(value, WaniKaniApiKeyPattern))
                throw new ArgumentException(nameof(value), "Invalid API token format.");

            _token = value;
        }
    }

    public void SetClientToken(string token)
    {
        Token = token;

        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
    }

    public void SetClientBaseAddress(Uri uri)
    {
        client.BaseAddress = uri;
    }
}