using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class Coleccion
    {
        public Coleccion()
        {
            Libros = new HashSet<Libro>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int? IdUbicacionBiblioteca { get; set; }

        public virtual UbicacionBiblioteca? IdUbicacionBibliotecaNavigation { get; set; }
        public virtual ICollection<Libro> Libros { get; set; }
    }
}
