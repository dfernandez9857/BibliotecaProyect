using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Autor
    {
        public Autor()
        {
            Libros = new HashSet<Libro>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
