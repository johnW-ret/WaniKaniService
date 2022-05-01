using WaniKaniService.Models;

namespace WaniKaniService;

public abstract class CollectionClient<T> : Client, ICollectionClient<T>, ICollectionClient
{
    protected CollectionClient(HttpClient client) : base(client) { }

    private const int MaximumPageCount = 100;

    public async Task<PagesCollection<T>> GetAllAsync(string filter, int pages = MaximumPageCount)
    {
        PagesCollection<T> responseCollection = new PagesCollection<T>();
        CollectionResponse<T>? response;

        // get initial request url
        string? requestUri = ResponseName;

        if (!string.IsNullOrEmpty(filter))
            requestUri += $"?{filter}";

        int i = 0;
        do
        {
            response = await GetResponse<CollectionResponse<T>>(requestUri);
            responseCollection.Add(response);
        }
        while ((requestUri = response.Pages.NextUrl?.AbsoluteUri ?? null) != null && ++i < pages);

        return responseCollection;
    }

    public async Task<Resource<T>> GetAsync(int id)
    {
        return await GetResponse<Resource<T>>($"{ResponseName}/{id}");
    }

    async Task<object> ICollectionClient.GetAsync(int id)
    {
        return await GetAsync(id);
    }

    async Task<object> ICollectionClient.GetAllAsync(string filter, int pages)
    {
        return await GetAllAsync(filter, pages);
    }

    async Task<object> ICollectionClient.GetAllAsync(string filter)
    {
        return await GetAllAsync(filter);
    }

    async Task<PagesCollection<T>> ICollectionClient<T>.GetAllAsync(string filter)
    {
        return await GetAllAsync(filter);
    }
}
