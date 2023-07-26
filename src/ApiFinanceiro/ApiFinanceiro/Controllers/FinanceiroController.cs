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

        [HttpGet("download-boleto/{guid}")]
        public IActionResult DownloadBoleto(Guid guid)
        {
            string nomeArquivo = $"boleto-{guid}.pdf";

            string caminhoArquivo = (Directory.GetCurrentDirectory() + $"/boletos/boleto-{guid}.pdf");

            if (OperatingSystem.IsWindows())
            {
                caminhoArquivo = (Directory.GetCurrentDirectory() + $"\\bin\\Debug\\net6.0\\boleto-{guid}.pdf");
            }

            // Verifica se o arquivo existe
            if (System.IO.File.Exists(caminhoArquivo))
            {
                byte[] conteudoArquivo = System.IO.File.ReadAllBytes(caminhoArquivo);
                string contentType = "application/pdf";

                return File(conteudoArquivo, contentType, nomeArquivo);
            }

            return NotFound();
        }
    }
}