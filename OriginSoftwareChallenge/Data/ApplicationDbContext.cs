using Microsoft.EntityFrameworkCore;
using OriginSoftwareChallenge.Models;

namespace OriginSoftwareChallenge.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Operacion> Operaciones { get; set; }

    }
}
