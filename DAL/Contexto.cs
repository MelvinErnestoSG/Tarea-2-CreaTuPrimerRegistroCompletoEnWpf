using Microsoft.EntityFrameworkCore;
using Tarea_2_CreaTuPrimerRegistroCompletoEnWpf.Entidades;

namespace Tarea_2_CreaTuPrimerRegistroCompletoEnWpf.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Roles> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=DATA\GestionRoles.db");
        }
    }
}
