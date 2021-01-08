using Microsoft.AspNetCore.Mvc;
using QRGenerator.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QRGenerator.Controllers
{
    [Route("api/Controller")]
    [ApiController]
    public class GeneradorController : Controller
    {
        [HttpGet("QRCode")]
        public IActionResult Image()
        {
            GeneradorHelper generador = new GeneradorHelper();
            Byte[] qr = generador.GererarQR();

            return File(qr,"image/png");

        }
    }
}
