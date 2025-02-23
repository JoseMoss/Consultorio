using System.ComponentModel.DataAnnotations;

namespace SystemOdonto.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }  // Se recomienda solo "Id" en lugar de "IdPaciente"

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El pago inicial es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El pago inicial no puede ser negativo")]
        public decimal PagoInicial { get; set; }

        [Required(ErrorMessage = "La mensualidad es obligatoria")]
        [Range(0, double.MaxValue, ErrorMessage = "La mensualidad no puede ser negativa")]
        public decimal Mensualidad { get; set; }
    }
}


