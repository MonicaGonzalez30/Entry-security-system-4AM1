using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ProyectoBack.Context;
using ProyectoBack.DTO;

namespace ProyectoBack.Controllers
{
    [Route("[controller]/datos")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("{id}")]
        public JsonResult GetAlumnoById(string id)
        {
            using (ContextoAPP Contexto = new ContextoAPP())
            {
                var userAlumno = Contexto.Alumnos.Find(id);
                var userAdmin = Contexto.Administrativos.Find(id);
                var userCafe = Contexto.Cafeteria.Find(id);
                var userInten = Contexto.Intendencia.Find(id);
                var userMaestro = Contexto.Maestros.Find(id);
                var userPolicia = Contexto.Policia.Find(id);
                if (userAlumno != null)
                {
                    return new JsonResult(new UsuarioDTO
                    {
                        name = userAlumno.name,
                        apePat = userAlumno.apePat,
                        apeMat = userAlumno.apeMat,
                        photo = userAlumno.photo,
                        tipoUsuario = "Alumno"
                    });
                }
                else if (userAdmin != null)
                {
                    return new JsonResult(new UsuarioDTO
                    {
                        name = userAdmin.name,
                        apePat = userAdmin.apePat,
                        apeMat = userAdmin.apeMat,
                        photo = userAdmin.photo,
                        tipoUsuario = "Administrativo"
                    });
                }
                else if (userCafe != null)
                {
                    return new JsonResult(new UsuarioDTO
                    {
                        name = userCafe.name,
                        apePat = userCafe.apePat,
                        apeMat = userCafe.apeMat,
                        photo = userCafe.photo,
                        tipoUsuario = "Cafeteria"
                    });
                }
                else if (userInten != null)
                {
                    return new JsonResult(new UsuarioDTO
                    {
                        name = userInten.name,
                        apePat = userInten.apePat,
                        apeMat = userInten.apeMat,
                        photo = userInten.photo,
                        tipoUsuario = "Intendencia"
                    });
                }
                else if (userMaestro != null)
                {
                    return new JsonResult(new UsuarioDTO
                    {
                        name = userMaestro.name,
                        apePat = userMaestro.apePat,
                        apeMat = userMaestro.apeMat,
                        photo = userMaestro.photo,
                        tipoUsuario = "Maestro"
                    });
                }
                else if (userPolicia != null)
                {
                    return new JsonResult(new UsuarioDTO
                    {
                        name = userPolicia.name,
                        apePat = userPolicia.apePat,
                        apeMat = userPolicia.apeMat,
                        photo = userPolicia.photo,
                        tipoUsuario = "Policia"
                    });
                }
                else
                {
                    return new JsonResult($"No se ha encontrado un registro del usuario con el identificador {id}");
                }
            }
        }

    }
}
