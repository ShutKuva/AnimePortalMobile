using System.Threading.Tasks;

namespace AnimePortalMobile.Abstractions
{
    public interface ISaveHandler<TKey, TData>
    {
        Task SaveDataAsync(TKey key, TData data);
        Task<TData> GetDataAsync(TKey key, TData defaultData);
        Task<bool> IsDataExistAsync(TKey key);
        Task RemoveDataAsync(TKey key);
    }
}