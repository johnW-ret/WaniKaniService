using WaniKaniService.Models;

namespace WaniKaniService;

public class AssignmentsClient : CollectionClient<Assignment>
{
    public AssignmentsClient(HttpClient client) : base(client) { }

    protected override string ResponseName => "assignments";
}