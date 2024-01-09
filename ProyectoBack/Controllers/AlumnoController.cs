using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ProyectoBack.Context;
using ProyectoBack.Model;

namespace ProyectoBack.Controllers
{
    [Route("[controller]/datos")]
    [ApiController]
    public class AlumnoController : ControllerBase
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
                        boleta = alumno.boleta,
                        password = alumno.password,
                        name = alumno.name,
                        apePat = alumno.apePat,
                        apeMat = alumno.apeMat,
                        photo = alumno.photo,
                        estado = alumno.estado
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
                var existingAlumno = contexto.Alumnos.SingleOrDefault(a => a.boleta == alumno.boleta);
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
                var existingAlumno = contexto.Alumnos.SingleOrDefault(a => a.boleta == alumno.boleta);
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

        [HttpGet("{id}")]
        public JsonResult GetAlumnoById(string id)
        {
            using (ContextoAPP Contexto = new ContextoAPP())
            {
                var alumno = Contexto.Alumnos.Find(id);
                if (alumno != null)
                {
                    return new JsonResult(new Alumno
                    {
                        password = alumno.password,
                        name = alumno.name,
                        apePat = alumno.apePat,
                        apeMat = alumno.apeMat,
                        photo = alumno.photo
                    });
                }
                else
                {
                    return new JsonResult($"No se ha encontrado un registro de alumno con la boleta {id}");
                }
            }
        }

    }
}
