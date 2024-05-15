using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class EstadoDetalle
    {
        public EstadoDetalle()
        {
            DetallePrestamos = new HashSet<DetallePrestamo>();
        }

        public int Id { get; set; }
        public string? Descipcion { get; set; }

        public virtual ICollection<DetallePrestamo> DetallePrestamos { get; set; }
    }
}
