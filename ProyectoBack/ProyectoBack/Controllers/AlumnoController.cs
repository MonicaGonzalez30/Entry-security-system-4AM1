using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ProyectoBack.Context;
using ProyectoBack.Model;

namespace ProyectoBack.Controllers
{
    [ApiController]
    [Route("Alumno")]
    public class AlumnoControllers : ControllerBase
    {
        [HttpGet]
        public JsonResult GetAlumnos()
        {
            List<Alumno> alumnosList = new List<Alumno>();
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var alumnos = contexto.Alumnos;
                foreach (var alumno in alumnos)
                {
                    alumnosList.Add(new Alumno
                    {
                        Boleta = alumno.Boleta,
                        Contraseña = alumno.Contraseña,
                        NombreCompleto = alumno.NombreCompleto,
                        Foto = alumno.Foto,
                        EstadoActual = alumno.EstadoActual
                    });
                }
            }
            return new JsonResult(alumnosList);
        }

        [HttpPost]
        public JsonResult PostAlumno([FromBody] Alumno alumno)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                contexto.Alumnos.Add(alumno);
                contexto.SaveChanges();
                success = true;
            }

            return new JsonResult(success);
        }

        [HttpPatch]
        public JsonResult PatchAlumno([FromBody] Alumno alumno)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var existingAlumno = contexto.Alumnos.SingleOrDefault(a => a.Boleta == alumno.Boleta);
                if (existingAlumno != null)
                {
                    contexto.Entry(existingAlumno).State = EntityState.Detached;
                    contexto.Alumnos.Attach(alumno);
                    contexto.Entry(alumno).State = EntityState.Modified;
                    contexto.SaveChanges();
                    success = true;
                }
            }
            return new JsonResult(success);
        }

        [HttpDelete]
        public JsonResult DeleteAlumno([FromBody] Alumno alumno)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var existingAlumno = contexto.Alumnos.SingleOrDefault(a => a.Boleta == alumno.Boleta);
                if (existingAlumno != null)
                {
                    contexto.Entry(existingAlumno).State = EntityState.Detached;
                    contexto.Alumnos.Attach(alumno);
                    contexto.Entry(alumno).State = EntityState.Deleted;
                    contexto.SaveChanges();
                    success = true;
                }
            }
            return new JsonResult(success);
        }
    }
}
