using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Libros = new HashSet<Libro>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
