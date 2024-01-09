










using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ProyectoBack.Context;
using ProyectoBack.DTO;
using QRCoder;
using System.IO;
using ProyectoBack.Model;

namespace ProyectoBack.Controllers
{
    [Route("[controller]/datos")]
    [ApiController]
    public class QRController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetUsuarioQR(string id)
        {
            using (ContextoAPP Contexto = new ContextoAPP())
            {
                // Find the user
                var userAlumno = Contexto.Alumnos.Find(id);
                var userAdmin = Contexto.Administrativos.Find(id);
                var userCafe = Contexto.Cafeteria.Find(id);
                var userInten = Contexto.Intendencia.Find(id);
                var userMaestro = Contexto.Maestros.Find(id);
                var userPolicia = Contexto.Policia.Find(id);

                if (userAlumno != null)
                {
                    var tipoUsuario = "Alumno";
                    var data = $"{userAlumno.boleta} {userAlumno.name} {userAlumno.apePat} {userAlumno.apeMat}  {tipoUsuario}";

                    var qrGenerator = new QRCodeGenerator();
                    var qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
                    BitmapByteQRCode bitmapByteCode = new BitmapByteQRCode(qrCodeData);
                    var bitMap = bitmapByteCode.GetGraphic(20);

                    using var ms = new MemoryStream();
                    ms.Write(bitMap);
                    byte[] byteImage = ms.ToArray();
                    return File(byteImage, "image/png");
                }
                else if (userAdmin != null)
                {
                    var tipoUsuario = "Administrativo";
                    var data = $"{userAdmin.idAdmin} {userAdmin.name} {userAdmin.apePat} {userAdmin.apeMat}  {tipoUsuario}";

                    var qrGenerator = new QRCodeGenerator();
                    var qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
                    BitmapByteQRCode bitmapByteCode = new BitmapByteQRCode(qrCodeData);
                    var bitMap = bitmapByteCode.GetGraphic(20);

                    using var ms = new MemoryStream();
                    ms.Write(bitMap);
                    byte[] byteImage = ms.ToArray();
                    return File(byteImage, "image/png");
                }
                else if (userCafe != null)
                {
                    var tipoUsuario = "Cafeteria";
                    var data = $"{userCafe.idCafe} {userCafe.name} {userCafe.apePat} {userCafe.apeMat} {tipoUsuario}";

                    var qrGenerator = new QRCodeGenerator();
                    var qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
                    BitmapByteQRCode bitmapByteCode = new BitmapByteQRCode(qrCodeData);
                    var bitMap = bitmapByteCode.GetGraphic(20);

                    using var ms = new MemoryStream();
                    ms.Write(bitMap);
                    byte[] byteImage = ms.ToArray();
                    return File(byteImage, "image/png");
                }
                else if (userInten != null)
                {
                    var tipoUsuario = "Intendencia";
                    var data = $"{userInten.idInten} {userInten.name}   {userInten.apePat}   {userInten.apeMat} {tipoUsuario}";

                    var qrGenerator = new QRCodeGenerator();
                    var qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
                    BitmapByteQRCode bitmapByteCode = new BitmapByteQRCode(qrCodeData);
                    var bitMap = bitmapByteCode.GetGraphic(20);

                    using var ms = new MemoryStream();
                    ms.Write(bitMap);
                    byte[] byteImage = ms.ToArray();
                    return File(byteImage, "image/png");
                }
                else if (userMaestro != null)
                {
                    var tipoUsuario = "Maestro";
                    var data = $"{userMaestro.idMaestro} {userMaestro.name} {userMaestro.apePat} {userMaestro.apeMat} {tipoUsuario}";

                    var qrGenerator = new QRCodeGenerator();
                    var qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
                    BitmapByteQRCode bitmapByteCode = new BitmapByteQRCode(qrCodeData);
                    var bitMap = bitmapByteCode.GetGraphic(20);

                    using var ms = new MemoryStream();
                    ms.Write(bitMap);
                    byte[] byteImage = ms.ToArray();
                    return File(byteImage, "image/png");
                }
                else if (userPolicia != null)
                {
                    var tipoUsuario = "Policia";
                    var data = $"{userPolicia.idPoli}   {userPolicia.name} {userPolicia.apePat}   {userPolicia.apeMat} {tipoUsuario}";

                    var qrGenerator = new QRCodeGenerator();
                    var qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
                    BitmapByteQRCode bitmapByteCode = new BitmapByteQRCode(qrCodeData);
                    var bitMap = bitmapByteCode.GetGraphic(20);

                    using var ms = new MemoryStream();
                    ms.Write(bitMap);
                    byte[] byteImage = ms.ToArray();
                    return File(byteImage, "image/png");
                }
                else
                {
                    return NotFound($"No se ha encontrado un registro del usuario con el identificador {id}");
                }
            }
        }
    }
}
