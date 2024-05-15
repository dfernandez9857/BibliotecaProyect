using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class HistoricoPrestamo
    {
        public int IdPrestamo { get; set; }
        public DateTime? Fecha { get; set; }
        public int IdEstado { get; set; }
        public int? IdUsuarioRegistro { get; set; }
        public string? Observacion { get; set; }
        public bool? Estado { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; } = null!;
        public virtual Prestamo IdPrestamoNavigation { get; set; } = null!;
        public virtual Usuario? IdUsuarioRegistroNavigation { get; set; }
    }
}
