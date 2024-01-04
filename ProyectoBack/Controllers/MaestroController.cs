using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ProyectoBack.Context;
using ProyectoBack.Model;

namespace ProyectoBack.Controllers
{
    [ApiController]
    [Route("Maestro")]
    public class MaestroController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetMaestros()
        {
            List<Maestro> maestrosList = new List<Maestro>();
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var maestros = contexto.Maestros;
                foreach (var maestro in maestros)
                {
                    maestrosList.Add(new Maestro
                    {
                        idMaestro = maestro.idMaestro,
                        password = maestro.password,
                        name = maestro.name,
                        apePat = maestro.apePat,
                        apeMat = maestro.apeMat,
                        photo = maestro.photo
                    });
                }
            }
            return new JsonResult(maestrosList);
        }

        [HttpPost]
        public JsonResult PostMaestro([FromBody] Maestro maestro)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                contexto.Maestros.Add(maestro);
                contexto.SaveChanges();
                success = true;
            }

            return new JsonResult(success);
        }

        [HttpPatch]
        public JsonResult PatchMaestro([FromBody] Maestro maestro)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var existingMaestro = contexto.Maestros.SingleOrDefault(m => m.idMaestro == maestro.idMaestro);
                if (existingMaestro != null)
                {
                    contexto.Entry(existingMaestro).State = EntityState.Detached;
                    contexto.Maestros.Attach(maestro);
                    contexto.Entry(maestro).State = EntityState.Modified;
                    contexto.SaveChanges();
                    success = true;
                }
            }
            return new JsonResult(success);
        }

        [HttpDelete]
        public JsonResult DeleteMaestro([FromBody] Maestro maestro)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var existingMaestro = contexto.Maestros.SingleOrDefault(m => m.idMaestro == maestro.idMaestro);
                if (existingMaestro != null)
                {
                    contexto.Entry(existingMaestro).State = EntityState.Detached;
                    contexto.Maestros.Attach(maestro);
                    contexto.Entry(maestro).State = EntityState.Deleted;
                    contexto.SaveChanges();
                    success = true;
                }
            }
            return new JsonResult(success);
        }
    }
}
