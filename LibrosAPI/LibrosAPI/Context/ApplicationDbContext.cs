using LibrosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrosAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Libro> Libros { get; set; }
    }
}
