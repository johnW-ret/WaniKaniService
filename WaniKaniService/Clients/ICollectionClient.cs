using WaniKaniService.Models;

namespace WaniKaniService;

public interface ICollectionClient<T>
{
    Task<Resource<T>> GetAsync(int id);
    Task<PagesCollection<T>> GetAllAsync(string filter, int pages = default);
}