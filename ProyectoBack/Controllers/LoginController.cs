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
                var alumno = contexto.Alumnos.FirstOrDefault(a => a.boleta == usuario.idUsuario && a.password == usuario.password);
                if (alumno != null)
                {
                    login = true;
                }

                // Buscar en la tabla de maestros
                var maestro = contexto.Maestros.FirstOrDefault(m => m.idMaestro == usuario.idUsuario && m.password == usuario.password);
                if (maestro != null)
                {
                    login = true;
                }

                // Buscar en la tabla de policia
                var Policia = contexto.Policia.FirstOrDefault(p => p.idPoli == usuario.idUsuario && p.password == usuario.password);
                if (Policia != null)
                {
                    login = true;
                }

                // Buscar en la tabla de intendencia
                var Intendencia = contexto.Intendencia.FirstOrDefault(i => i.idInten == usuario.idUsuario && i.password == usuario.password);
                if (Intendencia != null)
                {
                    login = true;
                }

                // Buscar en la tabla de cafeteria
                var Cafeteria = contexto.Cafeteria.FirstOrDefault(c => c.idCafe == usuario.idUsuario && c.password == usuario.password);
                if (Cafeteria != null)
                {
                    login = true;
                }

                // Buscar en la tabla de administrativos
                var administrativo = contexto.Administrativos.FirstOrDefault(a => a.idAdmin == usuario.idUsuario && a.password == usuario.password);
                if (administrativo != null)
                {
                    login = true;
                }
            }
            return login;
        }
    }
}
