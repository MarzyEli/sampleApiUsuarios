using Data.Schema;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class BsUsuario : IBsUsuario
    {
        private readonly db_punto_de_ventaContext context = null;
        public BsUsuario(db_punto_de_ventaContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> actualizarUsuario(Usuario usuario)
        {
            CatUsuario itemUsuario;
            itemUsuario = await context.CatUsuario.FindAsync(usuario.IdUsuario);
            itemUsuario.Nombre = usuario.Nombre;
            itemUsuario.ApPaterno = usuario.ApellidoPaterno;
            itemUsuario.ApMaterno = usuario.ApellidoMaterno;
            itemUsuario.Usuario = usuario.DsUsuario;
            itemUsuario.Contraseña = usuario.Contrasenia;
            itemUsuario.Email = usuario.Email;
            itemUsuario.Activo = usuario.Activo;
            itemUsuario.IdRol = usuario.IdRol;
           
            return await context.SaveChangesAsync();
        }

        public async Task<int> agregarUsuario(Usuario usuario)
        {
            try
            {
                var itemUsuario = new CatUsuario
                {
                    Nombre = usuario.Nombre,
                    ApPaterno = usuario.ApellidoPaterno,
                    ApMaterno = usuario.ApellidoMaterno,
                    Usuario = usuario.DsUsuario,
                    Contraseña = usuario.Contrasenia,
                    Email = usuario.Email,
                    Activo = usuario.Activo,
                    IdRol = usuario.IdRol
                };
                context.CatUsuario.Add(itemUsuario);
                return await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return 0;
            }
          
        }

        public async Task<int> eliminarUsuario(long idUsuario)
        {
            CatUsuario itemUsuario;
            itemUsuario = await context.CatUsuario.FindAsync(idUsuario);
            context.CatUsuario.Remove(itemUsuario);
            return await context.SaveChangesAsync();
        }

        public async Task<List<Usuario>> obtenerUsuarios()
        {
            Task<List<Usuario>> listaUsuarios;
            listaUsuarios = context.CatUsuario
            .Select(usuario => new Usuario
            {
                IdUsuario = usuario.IdUsuario,
                Nombre= usuario.Nombre,
                ApellidoPaterno = usuario.ApPaterno,
                ApellidoMaterno = usuario.ApMaterno,
                DsUsuario = usuario.Usuario,
                Contrasenia = usuario.Contraseña,
                Email = usuario.Email,
                Activo = usuario.Activo,
                IdRol = usuario.IdRol
            })
            .ToListAsync();
            return await listaUsuarios;
        }
    }
}
