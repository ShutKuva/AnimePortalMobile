namespace AnimePortalMobile.Abstractions
{
    public interface ISaveHandler<TKey, TData>
    {
        Task SaveDataAsync(TKey key, TData data);
        Task<TData> GetDataAsync(TKey key, TData defaultData);
        Task RemoveDataAsync(TKey key);
    }
}