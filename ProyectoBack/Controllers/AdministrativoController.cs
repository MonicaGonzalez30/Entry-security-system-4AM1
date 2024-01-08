using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ProyectoBack.Context;
using ProyectoBack.Model;

namespace ProyectoBack.Controllers
{
    [Route("[controller]/datos")]
    [ApiController]
    public class AdministrativoController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetAdministrativos()
        {
            List<Administrativo> administrativosList = new List<Administrativo>();
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var administrativos = contexto.Administrativos;
                foreach (var administrativo in administrativos)
                {
                    administrativosList.Add(new Administrativo
                    {
                        idAdmin = administrativo.idAdmin,
                        password = administrativo.password,
                        name = administrativo.name,
                        apePat = administrativo.apePat,
                        apeMat = administrativo.apeMat,
                        photo = administrativo.photo,
                        departamentoAdmin = administrativo.departamentoAdmin,
                        correoAdmin = administrativo.correoAdmin
                    });
                }
            }
            return new JsonResult(administrativosList);
        }

        [HttpPost]
        public JsonResult PostAdministrativo([FromBody] Administrativo administrativo)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                contexto.Administrativos.Add(administrativo);
                contexto.SaveChanges();
                success = true;
            }

            return new JsonResult(success);
        }

        [HttpPatch]
        public JsonResult PatchAdministrativo([FromBody] Administrativo administrativo)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var existingAdministrativo = contexto.Administrativos.SingleOrDefault(a => a.idAdmin == administrativo.idAdmin);
                if (existingAdministrativo != null)
                {
                    contexto.Entry(existingAdministrativo).State = EntityState.Detached;
                    contexto.Administrativos.Attach(administrativo);
                    contexto.Entry(administrativo).State = EntityState.Modified;
                    contexto.SaveChanges();
                    success = true;
                }
            }
            return new JsonResult(success);
        }

        [HttpDelete]
        public JsonResult DeleteAdministrativo([FromBody] Administrativo administrativo)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var existingAdministrativo = contexto.Administrativos.SingleOrDefault(a => a.idAdmin == administrativo.idAdmin);
                if (existingAdministrativo != null)
                {
                    contexto.Entry(existingAdministrativo).State = EntityState.Detached;
                    contexto.Administrativos.Attach(administrativo);
                    contexto.Entry(administrativo).State = EntityState.Deleted;
                    contexto.SaveChanges();
                    success = true;
                }
            }
            return new JsonResult(success);
        }

        [HttpGet("{id}")]
        public JsonResult GetAdministrativoById(string id)
        {
            using (ContextoAPP Contexto = new ContextoAPP())
            {
                var administrativo = Contexto.Administrativos.Find(id);
                if (administrativo != null)
                {
                    // Devuelve la información del administrador si se encuentra
                    return new JsonResult(new Administrativo
                    {
                        password = administrativo.password,
                        name = administrativo.name,
                        apePat = administrativo.apePat,
                        apeMat = administrativo.apeMat,
                        photo = administrativo.photo,
                        departamentoAdmin = administrativo.departamentoAdmin,
                        correoAdmin = administrativo.correoAdmin
                    });
                }
                else
                {
                    // Devuelve un mensaje indicando que no se encontró el administrador con el ID especificado
                    return new JsonResult($"No se ha encontrado un registro de administrativo con el ID {id}");
                }
            }
        }
    }
}
