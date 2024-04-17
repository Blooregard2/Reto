using Microsoft.EntityFrameworkCore;
using Examen.Domain.Entities.Examen;

namespace Examen.Infraestructure.Repositories
{
    public class ExamenContext : DbContext
    {
        public DbSet<Users> Usuarios { get; set; }
        public DbSet<Med> Medicamentos { get; set; }
        public DbSet<Formas> formasfarmaceuticas { get; set; }

        public ExamenContext(DbContextOptions<ExamenContext> options) : base(options) { }
    }
}
