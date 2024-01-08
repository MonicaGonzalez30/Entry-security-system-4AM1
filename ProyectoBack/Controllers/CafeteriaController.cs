using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ProyectoBack.Context;
using ProyectoBack.Model;

namespace ProyectoBack.Controllers
{
    [Route("[controller]/datos")]
    [ApiController]
    public class CafeteriaController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetCafeteria()
        {
            List<Cafeteria> CafeteriaList = new List<Cafeteria>();
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var Cafeteria = contexto.Cafeteria;
                foreach (var cafeteria in Cafeteria)
                {
                    CafeteriaList.Add(new Cafeteria
                    {
                        idCafe = cafeteria.idCafe,
                        password = cafeteria.password,
                        name = cafeteria.name,
                        apePat = cafeteria.apePat,
                        apeMat = cafeteria.apeMat,
                        photo = cafeteria.photo,
                        correoCafe = cafeteria.correoCafe
                    });
                }
            }
            return new JsonResult(CafeteriaList);
        }

        [HttpPost]
        public JsonResult PostCafeteria([FromBody] Cafeteria cafeteria)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                contexto.Cafeteria.Add(cafeteria);
                contexto.SaveChanges();
                success = true;
            }

            return new JsonResult(success);
        }

        [HttpPatch]
        public JsonResult PatchCafeteria([FromBody] Cafeteria cafeteria)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var existingcafeteria = contexto.Cafeteria.SingleOrDefault(c => c.idCafe == cafeteria.idCafe);
                if (existingcafeteria != null)
                {
                    contexto.Entry(existingcafeteria).State = EntityState.Detached;
                    contexto.Cafeteria.Attach(cafeteria);
                    contexto.Entry(cafeteria).State = EntityState.Modified;
                    contexto.SaveChanges();
                    success = true;
                }
            }
            return new JsonResult(success);
        }

        [HttpDelete]
        public JsonResult DeleteCafeteria([FromBody] Cafeteria cafeteria)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var existingcafeteria = contexto.Cafeteria.SingleOrDefault(c => c.idCafe == cafeteria.idCafe);
                if (existingcafeteria != null)
                {
                    contexto.Entry(existingcafeteria).State = EntityState.Detached;
                    contexto.Cafeteria.Attach(cafeteria);
                    contexto.Entry(cafeteria).State = EntityState.Deleted;
                    contexto.SaveChanges();
                    success = true;
                }
            }
            return new JsonResult(success);
        }

        [HttpGet("{id}")]
        public JsonResult GetCafeteriaById(string id)
        {
            using (ContextoAPP Contexto = new ContextoAPP())
            {
                var cafeteria = Contexto.Cafeteria.Find(id);
                if (cafeteria != null)
                {
                    return new JsonResult(new Cafeteria
                    {
                        password = cafeteria.password,
                        name = cafeteria.name,
                        apePat = cafeteria.apePat,
                        apeMat = cafeteria.apeMat,
                        photo = cafeteria.photo,
                        correoCafe = cafeteria.correoCafe
                    });
                }
                else
                {
                    return new JsonResult($"No se ha encontrado un registro de cafeteria con el ID {id}");
                }
            }
        }

    }
}
