using System.ComponentModel.DataAnnotations;

namespace RestauranteAPI.Models
{
    public class Clientes
    {
        [Key] //Primary key/ identificador único de la tabla
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }

    }
}
