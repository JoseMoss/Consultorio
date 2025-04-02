using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SystemOdonto.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; } 

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string Direccion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "El pago inicial es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El pago inicial no puede ser negativo")]
        public decimal PagoInicial { get; set; }

        [Required(ErrorMessage = "La mensualidad es obligatoria")]
        [Range(0, double.MaxValue, ErrorMessage = "La mensualidad no puede ser negativa")]
        public decimal Mensualidad { get; set; }

        [Required(ErrorMessage = "El tipo de tratamiento es obligatorio")]
        public string TipoTratamiento { get; set; } = string.Empty;  

        [Required(ErrorMessage = "La fecha de inicio del tratamiento es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime FechaInicioTratamiento { get; set; }

        // Relación con TratamientoAdicional
        public virtual List<TratamientoAdicional> TratamientosAdicionales { get; set; } = new List<TratamientoAdicional>();

        // Propiedad calculada para obtener el costo total de tratamientos adicionales
        [NotMapped] // No se guarda en la base de datos
        public decimal CostoTotalTratamientosAdicionales => TratamientosAdicionales?.Sum(t => t.Costo) ?? 0;
    }
}
