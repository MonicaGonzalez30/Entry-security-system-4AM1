using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ProyectoBack.Context;
using ProyectoBack.Model;

namespace ProyectoBack.Controllers
{
    [ApiController]
    [Route("Administrativo")]
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
                        IdentificadorDelAdministrativo = administrativo.IdentificadorDelAdministrativo,
                        Contraseña = administrativo.Contraseña,
                        NombreCompleto = administrativo.NombreCompleto,
                        Foto = administrativo.Foto,
                        Departamento = administrativo.Departamento,
                        CorreoElectronico = administrativo.CorreoElectronico
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
                var existingAdministrativo = contexto.Administrativos.SingleOrDefault(a => a.IdentificadorDelAdministrativo == administrativo.IdentificadorDelAdministrativo);
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
                var existingAdministrativo = contexto.Administrativos.SingleOrDefault(a => a.IdentificadorDelAdministrativo == administrativo.IdentificadorDelAdministrativo);
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
    }
}
