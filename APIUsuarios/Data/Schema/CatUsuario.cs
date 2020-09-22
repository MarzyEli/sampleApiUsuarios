using System;
using System.Collections.Generic;

namespace Data.Schema
{
    public partial class CatUsuario
    {
        public int IdUsuario { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
        public int IdRol { get; set; }
    }
}
