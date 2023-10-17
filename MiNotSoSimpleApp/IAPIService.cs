public interface IApiService
{
    Task<IEnumerable<Post>> GetMyModelsAsync();
}
