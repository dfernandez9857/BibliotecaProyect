using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            HistoricoPrestamos = new HashSet<HistoricoPrestamo>();
            Prestamos = new HashSet<Prestamo>();
        }

        public int Id { get; set; }
        public string? Nombres { get; set; }
        public string? Direccion { get; set; }
        public string? Referencia { get; set; }
        public string? NroTelefono1 { get; set; }
        public string? NroTelefono2 { get; set; }
        public string? Apellidos { get; set; }
        public int? IdUbigeo { get; set; }
        public int? IdPerfil { get; set; }

        public virtual Perfil? IdPerfilNavigation { get; set; }
        public virtual ICollection<HistoricoPrestamo> HistoricoPrestamos { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
