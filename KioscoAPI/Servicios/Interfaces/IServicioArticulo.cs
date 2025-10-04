using KioscoAPI.DTOs;
using KioscoAPI.Models;

namespace KioscoAPI.Servicios.Interfaces
{
    public interface IServicioArticulo
    {
        Task<List<ArticuloDTO>> GetByCategoryAsync(string categoria);
        Task<List<ArticuloDTO>> GetByNombreAsync(string nombre);
        Task<List<ArticuloDTO>> GetAllAsync();
        Task<bool> CreateAsync(Articulo entity);
        Task<bool> UpdateAsync(Articulo entity, int id);
        Task<bool> DeleteAsync(int id);
    }
}
