using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class Estado
    {
        public Estado()
        {
            HistoricoPrestamos = new HashSet<HistoricoPrestamo>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<HistoricoPrestamo> HistoricoPrestamos { get; set; }
    }
}
