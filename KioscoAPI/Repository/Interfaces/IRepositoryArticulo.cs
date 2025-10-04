using KioscoAPI.Models;

namespace KioscoAPI.Repository.Interfaces
{
    public interface IRepositoryArticulo : IRepositoryArticuloCategoria<Articulo>
    {
        Task<List<Articulo>> GetByCategoryAsync(string categoria);
        Task<List<Articulo>> GetByNombreAsync(string nombre);
    }
}
