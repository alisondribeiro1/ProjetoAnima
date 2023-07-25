using Microsoft.AspNetCore.Mvc;

namespace ApiFinanceiro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExemploController : ControllerBase
    {
        [HttpPost("gerar-boleto")]
        public IActionResult GerarBoleto([FromBody] BoletoModel dadosBoleto)
        {   
            Guid guid = Guid.NewGuid();

            string urlExemplo = $"https://www.exemplo.com/boleto/{guid}";

            PersistenciaPDF.GerarPdf(dadosBoleto, guid);

            return Ok(urlExemplo);
        }
    }
}