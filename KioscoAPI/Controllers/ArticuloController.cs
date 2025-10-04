using KioscoAPI.Models;
using KioscoAPI.Servicios.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KioscoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly IServicioArticulo _servicio;
        public ArticuloController(IServicioArticulo servicio)
        {
            _servicio = servicio;
        }

        // GET: api/<ArticuloController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var articulos = await _servicio.GetAllAsync();
            if (articulos == null)
                return NotFound("No se encontraron artículos.");
            return Ok(articulos);

        }

        // GET api/<ArticuloController?categoria=nombre
        [HttpGet("categoria/{categoria}")]
        public async Task<IActionResult> GetByCategoriaAsync(string categoria)
        {
            var articulos = await _servicio.GetByCategoryAsync(categoria);
            if (articulos == null)
                return NotFound($"No se encontraron artículos en la categoría: {categoria}");
            return Ok(articulos);
        }

        // GET api/<ArticuloController>/nombre
        [HttpGet("nombre/{nombre}")]
        public async Task<IActionResult> GetByNombreAsync(string nombre)
        {
            var articulos = await _servicio.GetByNombreAsync(nombre);
            if (articulos == null)
                return NotFound($"No se encontraron artículos con el nombre que comienza con: {nombre}");
            return Ok(articulos);
        }


        // POST api/<ArticuloController>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Articulo articulo)
        {
            return _servicio.CreateAsync(articulo).Result ?
                   Ok("Artículo creado exitosamente.") :
                   BadRequest("No se pudo crear el artículo.");
        }

        // PUT api/<ArticuloController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Articulo articulo)
        {
            return _servicio.UpdateAsync(articulo, id).Result ?
                   Ok("Artículo actualizado exitosamente.") :
                   BadRequest("No se pudo actualizar el artículo.");
        }

        // DELETE api/<ArticuloController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return _servicio.DeleteAsync(id).Result ?
                Ok("Articulo elminado exitosamente.") :
                BadRequest("No se pudo eliminar el arituclo.");
        }
    }
}
