using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Prestamo
    {
        public Prestamo()
        {
            DetallePrestamos = new HashSet<DetallePrestamo>();
            HistoricoPrestamos = new HashSet<HistoricoPrestamo>();
        }

        public int Id { get; set; }
        public int? IdUsuarioSolicitaPrestamo { get; set; }
        public string? Observacion { get; set; }
        public DateTime? FechaTentativaDevolver { get; set; }

        public virtual Usuario? IdUsuarioSolicitaPrestamoNavigation { get; set; }
        public virtual ICollection<DetallePrestamo> DetallePrestamos { get; set; }
        public virtual ICollection<HistoricoPrestamo> HistoricoPrestamos { get; set; }
    }
}
