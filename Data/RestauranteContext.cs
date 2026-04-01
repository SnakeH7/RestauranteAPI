using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Models;
namespace RestauranteAPI.Data
{
    public class RestauranteContext: DbContext
    {
        public RestauranteContext(DbContextOptions<RestauranteContext> options): base(options)
        {
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Productos> Productos { get; set; }

        public DbSet<Clientes> Clientes { get; set; }
    }
}
