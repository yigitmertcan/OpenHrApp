namespace HrApp.Interfaces.ApplicationServices
{
    public interface IRedisCacheService
    {
        Task<string> GetValueAsync(string key);
        Task<bool> SetValueAsync(string key, string value);
        Task Clear(string key);
        void ClearAll();

        Task<string> GetHashValueAsync(string key, string subkey);
        Task<bool> SetHashValueAsync(string key, string subkey, string value);
    }
}
