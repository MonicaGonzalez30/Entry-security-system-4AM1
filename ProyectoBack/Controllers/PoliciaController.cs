using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ProyectoBack.Context;
using ProyectoBack.Model;

namespace ProyectoBack.Controllers
{
    [Route("[controller]/datos")]
    [ApiController]
    public class PoliciaController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetPolicia()
        {
            List<Policia> PoliciaList = new List<Policia>();
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var Policia = contexto.Policia;
                foreach (var empleado in Policia)
                {
                    PoliciaList.Add(new Policia
                    {
                        idPoli = empleado.idPoli,
                        password = empleado.password,
                        name = empleado.name,
                        apePat = empleado.apePat,
                        apeMat = empleado.apeMat,
                        photo = empleado.photo,
                        correoPoli = empleado.correoPoli
                    });
                }
            }
            return new JsonResult(PoliciaList);
        }

        [HttpPost]
        public JsonResult PostPolicia([FromBody] Policia empleado)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                contexto.Policia.Add(empleado);
                contexto.SaveChanges();
                success = true;
            }

            return new JsonResult(success);
        }

        [HttpPatch]
        public JsonResult PatchPolicia([FromBody] Policia empleado)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var existingEmpleado = contexto.Policia.SingleOrDefault(e => e.idPoli == empleado.idPoli);
                if (existingEmpleado != null)
                {
                    contexto.Entry(existingEmpleado).State = EntityState.Detached;
                    contexto.Policia.Attach(empleado);
                    contexto.Entry(empleado).State = EntityState.Modified;
                    contexto.SaveChanges();
                    success = true;
                }
            }
            return new JsonResult(success);
        }

        [HttpDelete]
        public JsonResult DeletePolicia([FromBody] Policia empleado)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var existingEmpleado = contexto.Policia.SingleOrDefault(e => e.idPoli == empleado.idPoli);
                if (existingEmpleado != null)
                {
                    contexto.Entry(existingEmpleado).State = EntityState.Detached;
                    contexto.Policia.Attach(empleado);
                    contexto.Entry(empleado).State = EntityState.Deleted;
                    contexto.SaveChanges();
                    success = true;
                }
            }
            return new JsonResult(success);
        }

        [HttpGet("{id}")]
        public JsonResult GetPoliciaById(string id)
        {
            using (ContextoAPP Contexto = new ContextoAPP())
            {
                var policia = Contexto.Policia.Find(id);
                if (policia != null)
                {
                    // Devuelve la información del policia si se encuentra
                    return new JsonResult(new Policia
                    {
                        password = policia.password,
                        name = policia.name,
                        apePat = policia.apePat,
                        apeMat = policia.apeMat,
                        photo = policia.photo,
                        correoPoli = policia.correoPoli
                    });
                }
                else
                {
                    // Devuelve un mensaje indicando que no se encontró el policia con el ID especificado
                    return new JsonResult($"No se ha encontrado un registro de policia con el ID {id}");
                }
            }
        }

    }
}
