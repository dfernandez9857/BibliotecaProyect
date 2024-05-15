using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class Libro
    {
        public Libro()
        {
            DetallePrestamos = new HashSet<DetallePrestamo>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public int? IdAutor { get; set; }
        public bool? Estado { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdColeccion { get; set; }
        public int? PosicionColeccion { get; set; }

        public virtual Autor? IdAutorNavigation { get; set; }
        public virtual Categorium? IdCategoriaNavigation { get; set; }
        public virtual Coleccion? IdColeccionNavigation { get; set; }
        public virtual ICollection<DetallePrestamo> DetallePrestamos { get; set; }
    }
}
