using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ProyectoBack.Context;
using ProyectoBack.Model;

namespace ProyectoBack.Controllers
{
    [ApiController]
    [Route("RegistroEntradaSalida")]
    public class RegistroEntradaSalidaController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetRegistrosEntradaSalida()
        {
            List<RegistroEntradaSalida> registrosList = new List<RegistroEntradaSalida>();
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var registros = contexto.RegistrosEyS;
                foreach (var registro in registros)
                {
                    registrosList.Add(new RegistroEntradaSalida
                    {
                        ID = registro.ID,
                        Fecha = registro.Fecha,
                        Hora = registro.Hora,
                        idUsuario = registro.idUsuario,
                        TipoUsuario = registro.TipoUsuario,
                        Instalacion = registro.Instalacion,
                    });
                }
            }
            return new JsonResult(registrosList);
        }

        [HttpPost]
        public JsonResult PostRegistroEntradaSalida([FromBody] RegistroEntradaSalida registro)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                contexto.RegistrosEyS.Add(registro);
                contexto.SaveChanges();
                success = true;
            }

            return new JsonResult(success);
        }

        [HttpPatch]
        public JsonResult PatchRegistroEntradaSalida([FromBody] RegistroEntradaSalida registro)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var existingRegistro = contexto.RegistrosEyS.SingleOrDefault(r => r.ID == registro.ID);
                if (existingRegistro != null)
                {
                    contexto.Entry(existingRegistro).State = EntityState.Detached;
                    contexto.RegistrosEyS.Attach(registro);
                    contexto.Entry(registro).State = EntityState.Modified;
                    contexto.SaveChanges();
                    success = true;
                }
            }
            return new JsonResult(success);
        }

        [HttpDelete]
        public JsonResult DeleteRegistroEntradaSalida([FromBody] RegistroEntradaSalida registro)
        {
            bool success = false;
            using (ContextoAPP contexto = new ContextoAPP())
            {
                var existingRegistro = contexto.RegistrosEyS.SingleOrDefault(r => r.ID == registro.ID);
                if (existingRegistro != null)
                {
                    contexto.Entry(existingRegistro).State = EntityState.Detached;
                    contexto.RegistrosEyS.Attach(registro);
                    contexto.Entry(registro).State = EntityState.Deleted;
                    contexto.SaveChanges();
                    success = true;
                }
            }
            return new JsonResult(success);
        }
    }
}
