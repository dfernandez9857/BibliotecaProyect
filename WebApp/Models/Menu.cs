using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class Menu
    {
        public Menu()
        {
            IdPerfils = new HashSet<Perfil>();
        }

        public int IdMenu { get; set; }
        public string? Nombre { get; set; }
        public string? Url { get; set; }

        public virtual ICollection<Perfil> IdPerfils { get; set; }
    }
}
