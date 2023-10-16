using CRUDMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(
            DbContextOptions<ApplicationDBContext> options
            ) : base(options) { }
        
        public DbSet<Producto> Producto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    IdProducto = 12,
                    Nombre = "Producto1",
                    Descripcion = "Desc",
                    Cantidad = 12
                },
                new Producto
                {
                    IdProducto = 13,
                    Nombre = "Producto2",
                    Descripcion = "Desc2",
                    Cantidad = 10
                }

                );
        }



    }
}
