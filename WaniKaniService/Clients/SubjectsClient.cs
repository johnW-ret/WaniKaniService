using WaniKaniService.Models;

namespace WaniKaniService;

public class SubjectsClient : CollectionClient<Subject>
{
    public SubjectsClient(HttpClient client) : base(client) { }

    protected override string ResponseName => "subjects";
}