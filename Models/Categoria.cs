using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace RestauranteAPI.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }

        [JsonIgnore] //Evita crear un bucle infinito 
        public ICollection<Productos> productos { get; set; }
    }
}
