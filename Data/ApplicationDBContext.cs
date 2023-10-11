using CRUDMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(
            DbContextOptions<ApplicationDBContext> options
            ) : base(options) { }

            DbSet<Producto> Producto { get; set; }


    }
}
