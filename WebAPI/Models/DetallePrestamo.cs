using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class DetallePrestamo
    {
        public int IdPrestamo { get; set; }
        public int IdLibro { get; set; }
        public string? Observacion { get; set; }
        public int? IdEstadoDetalle { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual EstadoDetalle? IdEstadoDetalleNavigation { get; set; }
        public virtual Libro IdLibroNavigation { get; set; } = null!;
        public virtual Prestamo IdPrestamoNavigation { get; set; } = null!;
    }
}
