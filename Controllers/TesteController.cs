using Microsoft.AspNetCore.Mvc;

namespace TesteApi.Api
{
    public class TesteController : Controller
    {
        [HttpGet("Teste")]
        public IActionResult Teste()
        {
            return Ok("Nossa api está funcionando");
        }
    }
}