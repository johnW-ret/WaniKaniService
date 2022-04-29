using WaniKaniService.Models;

namespace WaniKaniService;

public class UserClient : ResponseClient<User>
{
    public UserClient(HttpClient client) : base(client) { }

    protected override string ResponseName => "user";
}