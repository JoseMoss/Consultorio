using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemOdonto.Models
{
    [Table("TratamientosAdicionales")]  // Esto indica el nombre exacto de la tabla en la base de datos
    public class TratamientoAdicional
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del tratamiento es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Range(0, double.MaxValue, ErrorMessage = "El costo debe ser un valor positivo")]
        public decimal Costo { get; set; }

        // Clave foránea para relacionar con Paciente
        public int PacienteId { get; set; }

        public Paciente? Paciente { get; set; }  // Relación de navegación (opcional)
    }
}
