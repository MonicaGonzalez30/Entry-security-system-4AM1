using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoBack.Context;
using ProyectoBack.Model;
using ProyectoBack.DTO;
using System.Linq;

namespace ProyectoBack.Controllers
{
    [ApiController]
    [Route("Login")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public bool LoginUsuarios([FromBody] LoginDTO usuario)
        {
            bool login = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                // Buscar en la tabla de alumnos
                var alumno = contexto.Alumnos.FirstOrDefault(a => a.Boleta == usuario.NombreUsuario && a.Contraseña == usuario.Contraseña);
                if (alumno != null)
                {
                    login = true;
                }

                // Buscar en la tabla de maestros
                var maestro = contexto.Maestros.FirstOrDefault(m => m.IdentificadorDeMaestro == usuario.NombreUsuario && m.Contraseña == usuario.Contraseña);
                if (maestro != null)
                {
                    login = true;
                }

                // Buscar en la tabla de personal general
                var personalGeneral = contexto.PersonalG.FirstOrDefault(p => p.IdentificadorDelPersonal == usuario.NombreUsuario && p.Contraseña == usuario.Contraseña);
                if (personalGeneral != null)
                {
                    login = true;
                }

                // Buscar en la tabla de administrativos
                var administrativo = contexto.Administrativos.FirstOrDefault(a => a.IdentificadorDelAdministrativo == usuario.NombreUsuario && a.Contraseña == usuario.Contraseña);
                if (administrativo != null)
                {
                    login = true;
                }
            }
            return login;
        }
    }
}
