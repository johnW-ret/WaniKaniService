namespace WaniKaniService;

public interface IResponseClient<T>
{
    Task<Response<T>> GetAsync();
}