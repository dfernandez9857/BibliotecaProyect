using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class UbicacionBiblioteca
    {
        public UbicacionBiblioteca()
        {
            Coleccions = new HashSet<Coleccion>();
        }

        public int Id { get; set; }
        public string? Seccion { get; set; }
        public string? Pabellon { get; set; }

        public virtual ICollection<Coleccion> Coleccions { get; set; }
    }
}
