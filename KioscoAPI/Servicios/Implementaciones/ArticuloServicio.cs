using KioscoAPI.DTOs;
using KioscoAPI.Models;
using KioscoAPI.Repository.Interfaces;
using KioscoAPI.Servicios.Interfaces;

namespace KioscoAPI.Servicios.Implementaciones
{
    public class ArticuloServicio : IServicioArticulo
    {
        private readonly IRepositoryArticulo _repository;
        public ArticuloServicio(IRepositoryArticulo repository)
        {
            _repository = repository;
        }
        public async Task<bool> CreateAsync(Articulo entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<List<ArticuloDTO>> GetAllAsync()
        {
            List<Articulo> articulos = await _repository.GetAllAsync();

            List<ArticuloDTO> articulosDTO = articulos.Select(a => new ArticuloDTO
            {
                IdArticulo = a.IdArticulo,
                Nombre = a.Nombre,
                Precio = a.Precio,
                Stock = a.Stock,
                categoria = new CategoriaDTO
                {
                    Id = a.IdCategoriaNavigation.IdCategoria,
                    Nombre = a.IdCategoriaNavigation.Nombre
                },
                Estado = a.Estado
            }).ToList();

            return articulosDTO;
        }

        public async Task<List<ArticuloDTO>> GetByCategoryAsync(string categoria)
        {
            var articulos = await _repository.GetByCategoryAsync(categoria);

            var articulosDTO = articulos.Select(a => new ArticuloDTO
            {
                IdArticulo = a.IdArticulo,
                Nombre = a.Nombre,
                Precio = a.Precio,
                Stock = a.Stock,
                categoria = new CategoriaDTO
                {
                    Id = a.IdCategoriaNavigation.IdCategoria,
                    Nombre = a.IdCategoriaNavigation.Nombre
                },
                Estado = a.Estado
            }).ToList();

            return articulosDTO;

        }

        public async Task<List<ArticuloDTO>> GetByNombreAsync(string nombre)
        {
            var articulos = await _repository.GetByNombreAsync(nombre);

            var articulosDTO = articulos.Select(a => new ArticuloDTO
            {
                IdArticulo = a.IdArticulo,
                Nombre = a.Nombre,
                Precio = a.Precio,
                Stock = a.Stock,
                categoria = new CategoriaDTO
                {
                    Id = a.IdCategoriaNavigation.IdCategoria,
                    Nombre = a.IdCategoriaNavigation.Nombre
                },
                Estado = a.Estado
            }).ToList();

            return articulosDTO;
        }

        public async Task<bool> UpdateAsync(Articulo entity, int id)
        {
            return await _repository.UpdateAsync(entity, id);
        }
    }
}
