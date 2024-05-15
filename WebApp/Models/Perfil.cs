using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class Perfil
    {
        public Perfil()
        {
            Usuarios = new HashSet<Usuario>();
            IdMenus = new HashSet<Menu>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }

        public virtual ICollection<Menu> IdMenus { get; set; }
    }
}
