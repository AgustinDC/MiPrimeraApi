using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi2.Model;
using MiPrimeraApi2.Repository;

namespace MiPrimeraApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentaController : ControllerBase
    {
        [HttpGet]
        public List<Usuario> GetUsuarios()
        {
            return new List<Usuario>();
        }


        [HttpGet("{NombreUsuario}/{Contraseña}")]
        public Usuario UsuarioConContraseña(string NombreUsuario, string Contraseña)
        {
            Usuario usuario = UsuarioHandler.UsuarioConContraseña(NombreUsuario, Contraseña);
            return new Usuario();
        }

        [HttpPost]
        public void Actualizar()
        {

        }

        [HttpPut]
        public void Crear()
        {
            
        }
        [HttpDelete]
        public void EliminarUsuario()
        {

        }
    }
}
