using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace ModeloApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("ObterDataHotaAtual")]
        public IActionResult ObeterDataHora()
        {
            var obj = new
            {
               data = DateTime.Now.ToLongDateString(),
               time = DateTime.Now.ToLongTimeString()
               
            };

            return Ok(obj);
        }

        [HttpGet("Apresentar/{nome}")]
        public IActionResult Apresentar(string nome)
        {
            string message = $"Olá {nome}, seja bem-vindo";
            return Ok(new { message });
        }
    }
}
