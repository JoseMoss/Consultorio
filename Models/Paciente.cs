using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public required string TipoTratamiento { get; set; } 

        [DataType(DataType.Date)]
        public DateTime FechaInicioTratamiento { get; set; }

        // ✅ Relación con TratamientoAdicional
        public List<TratamientoAdicional> TratamientosAdicionales { get; set; } = new List<TratamientoAdicional>();

        // ✅ Propiedad calculada para obtener el costo total de tratamientos adicionales
        public decimal CostoTotalTratamientosAdicionales => TratamientosAdicionales.Sum(t => t.Costo);
    }
}

