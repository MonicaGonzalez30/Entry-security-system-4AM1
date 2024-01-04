using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ProyectoBack.Context;
using ProyectoBack.Model;

namespace ProyectoBack.Controllers
{
    [ApiController]
    [Route("Intendencia")]
    public class IntendenciaController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetIntendencia()
        {
            List<Intendencia> IntendenciaList = new List<Intendencia>();
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var Intendencia = contexto.Intendencia;
                foreach (var intendencia in Intendencia)
                {
                    IntendenciaList.Add(new Intendencia
                    {
                        idInten = intendencia.idInten,
                        password = intendencia.password,
                        name = intendencia.name,
                        apePat = intendencia.apePat,
                        apeMat = intendencia.apeMat,
                        photo = intendencia.photo,
                        correoInten = intendencia.correoInten
                    });
                }
            }
            return new JsonResult(IntendenciaList);
        }

        [HttpPost]
        public JsonResult PostIntendencia([FromBody] Intendencia intendencia)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                contexto.Intendencia.Add(intendencia);
                contexto.SaveChanges();
                success = true;
            }

            return new JsonResult(success);
        }

        [HttpPatch]
        public JsonResult PatchIntendencia([FromBody] Intendencia intendencia)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var existingintendencia = contexto.Intendencia.SingleOrDefault(e => e.idInten == intendencia.idInten);
                if (existingintendencia != null)
                {
                    contexto.Entry(existingintendencia).State = EntityState.Detached;
                    contexto.Intendencia.Attach(intendencia);
                    contexto.Entry(intendencia).State = EntityState.Modified;
                    contexto.SaveChanges();
                    success = true;
                }
            }
            return new JsonResult(success);
        }

        [HttpDelete]
        public JsonResult DeleteIntendencia([FromBody] Intendencia intendencia)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var existingintendencia = contexto.Intendencia.SingleOrDefault(e => e.idInten == intendencia.idInten);
                if (existingintendencia != null)
                {
                    contexto.Entry(existingintendencia).State = EntityState.Detached;
                    contexto.Intendencia.Attach(intendencia);
                    contexto.Entry(intendencia).State = EntityState.Deleted;
                    contexto.SaveChanges();
                    success = true;
                }
            }
            return new JsonResult(success);
        }
    }
}
