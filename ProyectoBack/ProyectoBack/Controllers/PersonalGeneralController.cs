using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ProyectoBack.Context;
using ProyectoBack.Model;

namespace ProyectoBack.Controllers
{
    [ApiController]
    [Route("PersonalGeneral")]
    public class PersonalGeneralController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetPersonalGeneral()
        {
            List<PersonalGeneral> personalGeneralList = new List<PersonalGeneral>();
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var personalGeneral = contexto.PersonalG;
                foreach (var empleado in personalGeneral)
                {
                    personalGeneralList.Add(new PersonalGeneral
                    {
                        IdentificadorDelPersonal = empleado.IdentificadorDelPersonal,
                        Contraseña = empleado.Contraseña,
                        NombreCompleto = empleado.NombreCompleto,
                        Foto = empleado.Foto,
                        Puesto = empleado.Puesto,
                        CorreoElectronico = empleado.CorreoElectronico
                    });
                }
            }
            return new JsonResult(personalGeneralList);
        }

        [HttpPost]
        public JsonResult PostPersonalGeneral([FromBody] PersonalGeneral empleado)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                contexto.PersonalG.Add(empleado);
                contexto.SaveChanges();
                success = true;
            }

            return new JsonResult(success);
        }

        [HttpPatch]
        public JsonResult PatchPersonalGeneral([FromBody] PersonalGeneral empleado)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var existingEmpleado = contexto.PersonalG.SingleOrDefault(e => e.IdentificadorDelPersonal == empleado.IdentificadorDelPersonal);
                if (existingEmpleado != null)
                {
                    contexto.Entry(existingEmpleado).State = EntityState.Detached;
                    contexto.PersonalG.Attach(empleado);
                    contexto.Entry(empleado).State = EntityState.Modified;
                    contexto.SaveChanges();
                    success = true;
                }
            }
            return new JsonResult(success);
        }

        [HttpDelete]
        public JsonResult DeletePersonalGeneral([FromBody] PersonalGeneral empleado)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var existingEmpleado = contexto.PersonalG.SingleOrDefault(e => e.IdentificadorDelPersonal == empleado.IdentificadorDelPersonal);
                if (existingEmpleado != null)
                {
                    contexto.Entry(existingEmpleado).State = EntityState.Detached;
                    contexto.PersonalG.Attach(empleado);
                    contexto.Entry(empleado).State = EntityState.Deleted;
                    contexto.SaveChanges();
                    success = true;
                }
            }
            return new JsonResult(success);
        }
    }
}
