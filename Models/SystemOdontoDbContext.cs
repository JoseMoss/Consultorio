using Microsoft.EntityFrameworkCore;

namespace SystemOdonto.Models
{
    public class SystemOdontoDbContext : DbContext
    {
        public SystemOdontoDbContext(DbContextOptions<SystemOdontoDbContext> options) : base(options) { }

        // DbSets para las entidades
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<TratamientoAdicional> TratamientosAdicionales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurando la relación de uno a muchos entre Paciente y TratamientoAdicional
            modelBuilder.Entity<Paciente>()
                .HasMany(p => p.TratamientosAdicionales) // Un paciente puede tener muchos tratamientos adicionales
                .WithOne(t => t.Paciente) // Cada tratamiento adicional pertenece a un paciente
                .HasForeignKey(t => t.PacienteId) // La clave foránea
                .OnDelete(DeleteBehavior.Cascade); // Si se elimina un paciente, se eliminan los tratamientos adicionales
        }
    }
}
