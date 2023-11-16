using crud7MVC.Models;
using Microsoft.EntityFrameworkCore;


namespace MagicVilla.Datos
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Contacto> Contactos { get; set; }

    }
}