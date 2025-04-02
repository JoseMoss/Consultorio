using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemOdonto.Models
{
    [Table("TratamientosAdicionales")]  
    public class TratamientoAdicional
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del tratamiento es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Range(0, double.MaxValue, ErrorMessage = "El costo debe ser un valor positivo")]
        public decimal Costo { get; set; }

        // Clave foránea
        [ForeignKey("Paciente")]
        public int PacienteId { get; set; }

        // Relación de navegación asegurando la carga
        public virtual Paciente Paciente { get; set; } = null!;
    }
}
