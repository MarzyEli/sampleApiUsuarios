using Business;
using Data.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Threading.Tasks;

namespace APIUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly db_punto_de_ventaContext _context;
        private readonly IBsUsuario _bsUsuario = null;
        public UsuarioController(db_punto_de_ventaContext context, IBsUsuario bsUsuario)
        {
            _context = context;
            _bsUsuario = bsUsuario ?? throw new ArgumentNullException(nameof(bsUsuario));
        }

        [HttpPost("agregarUsuario")]
        public async Task<ActionResult> AgregarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                return Ok(await _bsUsuario.agregarUsuario(usuario));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("actualizarUsuario")]
        public async Task<ActionResult> ActualizarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                return Ok(await _bsUsuario.actualizarUsuario(usuario));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("eliminarUsuario/{idUsuario}")]
        public async Task<ActionResult> eliminarUsuario(long idUsuario)
        {
            try
            {
                return Ok(await _bsUsuario.eliminarUsuario(idUsuario));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("obtenerUsuarios")]
        public async Task<ActionResult> ObtenerUsuarios()
        {
            try
            {
                return Ok(await _bsUsuario.obtenerUsuarios());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
