using WaniKaniService.Models;

namespace WaniKaniService;

public abstract class ResponseClient<T> : Client, IResponseClient<T>, IResponseClient
{
    protected ResponseClient(HttpClient client) : base(client) { }

    public async Task<Response<T>> GetAsync()
    {
        return await GetResponse<Response<T>>(ResponseName);
    }

    async Task<object> IResponseClient.GetAsync()
    {
        return await GetAsync();
    }
}