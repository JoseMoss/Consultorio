using Microsoft.EntityFrameworkCore;

namespace SystemOdonto.Models
{
    public class SystemOdontoDbContext : DbContext
    {
        public SystemOdontoDbContext(DbContextOptions<SystemOdontoDbContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
    }
}
