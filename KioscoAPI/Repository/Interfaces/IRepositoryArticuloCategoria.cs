namespace KioscoAPI.Repository.Interfaces
{
    public interface IRepositoryArticuloCategoria<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity, int id);
        Task<bool> DeleteAsync(int id);
    }
}
