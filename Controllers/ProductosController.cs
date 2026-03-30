using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Data;
using RestauranteAPI.Models;

namespace RestauranteAPI.Controllers
{
    [Route("api/[controller]")] //Controller se convierte en la dirección URL
    [ApiController] //ApiController da funciones como code: 400, Binding más inteligente y alidación automática del modelo
    public class ProductosController : ControllerBase
    {
        private readonly RestauranteContext _context; //Dirección/acceso a la base de datos
        //IMPORTANTE!!!
        public ProductosController(RestauranteContext context) //Este contructor recibe la base de datoss y establece la comunicación
        {
            _context = context; 
        }

        [HttpGet] //Obtiene todos los items
        public async Task<ActionResult<IEnumerable<Productos>>> GetProductos()
        {
            var listaProductos = await _context.Productos.Include(p => p.Categoria).ToListAsync(); //ToListAsync devuelve una consulta SQL
            //.Include permite recuperar no solo los productos, también INCLUYE los datos de su Categoría
            //async permite usar await que a su vez permite liberar el hilo para realizar otra tarea y atender otras peticiones (escalabilidad) 
            return Ok(listaProductos); //devuelve Http:200 y JSON
        }

        [HttpPost] //

        public async Task<ActionResult<Productos>> PostProductos(Productos productos)
        {
            _context.Productos.Add(productos);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProductos), new { id = productos.IdProducto }, productos);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Productos>> PutProductos(int id, Productos productos)
        {
            if (id != productos.IdProducto) return BadRequest(); //BadRequest retorna Http:400/petición invalida por el usuario 
            _context.Entry(productos).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Productos>>DeleteProductos(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
