using WaniKaniService.Models;

namespace WaniKaniService;

public interface ICollectionClient<T>
{
    Task<Resource<T>> GetAsync(int id);
    Task<PagesCollection<T>> GetAllAsync(string filter);
    Task<PagesCollection<T>> GetAllAsync(string filter, int pages);
}

public interface ICollectionClient
{
    Task<object> GetAsync(int id);
    Task<object> GetAllAsync(string filter);
    Task<object> GetAllAsync(string filter, int pages);
}