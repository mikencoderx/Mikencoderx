using Microsoft.EntityFrameworkCore;
using Mikencoderx.Models;

namespace Mikencoderx.Context
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }

        public DbSet<Programadores> Programadores { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Proyectos> Proyectos { get; set; }
        public DbSet<Membresias> Membresias { get; set; }
        public DbSet<Planes> Planes { get; set; }
        public DbSet<Detalles> Detalles { get; set; }        
        public DbSet<Lenguajes> Lenguajes { get; set; }
        public DbSet<Administradores> Administradores { get; set; }
        public DbSet<Lista_PL> Lista_PL { get; set; }
        public DbSet<Registros> Registros { get; set; }

    }
}
