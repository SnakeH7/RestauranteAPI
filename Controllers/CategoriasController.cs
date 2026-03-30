using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Data;
using RestauranteAPI.Models;

namespace RestauranteAPI.Controllers
{
    // 1. [Route] es el letrero en la puerta. Dice que para hablar con este mesero
    // hay que ir a la dirección web: /api/Categorias
    [Route("api/[controller]")]
    [ApiController] // Le da superpoderes para validar datos automáticamente
    public class CategoriasController : ControllerBase
    {
        // 2. Aquí guardaremos el pase de acceso a la cocina
        private readonly RestauranteContext _context;

        public CategoriasController(RestauranteContext context)
        {
            _context = context;
        }

        // -------------------------------------------------------------------
        // 🚨 EL PRIMER ENDPOINT (La primera orden que sabe atender)
        // -------------------------------------------------------------------

        // 4. [HttpGet] significa que esta función se activa cuando alguien
        // pide "Leer" información (como leer el menú).
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            // 5. ¡LA MAGIA DE ENTITY FRAMEWORK!
            // Le decimos al contexto: "Ve a la tabla Categorias, conviértela en 
            // una lista de C# y entrégamela". EF Core traduce esto a: SELECT * FROM Categorias;
            var listaCategorias = await _context.Categorias.ToListAsync();

            // 6. El mesero entrega la orden al cliente
            return Ok(listaCategorias);
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategorias), new { id = categoria.IdCategoria }, categoria);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Categoria>> PutCategoria(int id, Categoria categoria)
        {
            if(id != categoria.IdCategoria)
            {
                return BadRequest();
            }
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null) return NotFound(); //código 404 (no encontrado)
            _context.Categorias.Remove(categoria); //si lo encontro eliminar la categoría
            await _context.SaveChangesAsync(); //guardamos los cambios para que EF viaje hasta SQL y realice la consula DELETE Categoria WHERE...
            return NoContent(); //Le indica al usuario/navegador que todo salió bien
        }
    }


}