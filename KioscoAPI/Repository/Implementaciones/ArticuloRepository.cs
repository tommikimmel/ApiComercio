using KioscoAPI.Models;
using KioscoAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KioscoAPI.Repository.Implementaciones
{
    public class ArticuloRepository : IRepositoryArticulo
    {
        private readonly KioscoDBContext _context;
        public ArticuloRepository(KioscoDBContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAsync(Articulo entity)
        {
            await _context.Articulos.AddAsync(entity);
            if (await _context.SaveChangesAsync() <= 0)
                return false;
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _context.Articulos
                        .Where(a => a.IdArticulo == id)
                        .ExecuteUpdateAsync(a => a.SetProperty(p => p.Estado, "Inactivo")) > 0;
        }

        public async Task<List<Articulo>> GetAllAsync()
        {
            return await _context.Articulos
                    .Include(a => a.IdCategoriaNavigation) // Incluir la categoría relacionada
                    .ToListAsync();
        }

        public Task<List<Articulo>> GetByCategoryAsync(string categoria)
        {
            return _context.Articulos
                    .Include(a => a.IdCategoriaNavigation) // Incluir la categoría relacionada
                        .Where(a => a.IdCategoriaNavigation.Nombre == categoria)
                    .ToListAsync();
        }

        public async Task<List<Articulo>> GetByNombreAsync(string nombre)
        {
            return await _context.Articulos
                        .Include(a => a.IdCategoriaNavigation) // Incluir la categoría relacionada
                       .Where(a => a.Nombre.StartsWith(nombre))
                       .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Articulo entity, int id)
        {
            return await _context.Articulos
                        .Where(a => a.IdArticulo == id)
                        .ExecuteUpdateAsync(a => a
                            .SetProperty(p => p.Nombre, entity.Nombre)
                            .SetProperty(p => p.Precio, entity.Precio)
                            .SetProperty(p => p.IdCategoria, entity.IdCategoria)
                            .SetProperty(p => p.Estado, entity.Estado)) > 0;
        }
    }
}
