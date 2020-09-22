using System;

namespace Models
{
    public class Usuario
    {
        public long IdUsuario { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombre { get; set; }
        public string DsUsuario { get; set; }
        public string Contrasenia { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
        public int IdRol { get; set; }
    }
}
