using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteAPI.Models
{
    public class Productos
    {
        [Key]
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        //Colocamos la llave foránea que tiene la BD para relacionarse 
        public int IdCategoria { get; set; }

        [ForeignKey("IdCategoria")] //Basicamente le dice a EF que use el número de arriba (IdCategoria) para buscarlo en la base de datos toda
        public Categoria? Categoria { get; set; }
    }
}
