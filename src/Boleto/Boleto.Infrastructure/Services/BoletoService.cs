using Boleto.Domain.Models;
using Boleto.Domain.SwaggerModels;
using Boleto.Infrastructure.Repositories.Interfaces;
using Boleto.Infrastructure.Services.Interfaces;
using Boleto.Infrastructure.Services.Request;
using Boleto.Infrastructure.Services.Requests;
using System.Net.Http.Json;

namespace Boleto.Infrastructure.Services
{
    public class BoletoService : IBoletoService
    {

        private readonly IBoletoRepository _boletoRepository;
        private readonly HttpClient _httpClient;

        public BoletoService(IBoletoRepository boletoRepository, HttpClient httpClient)
        {
            _boletoRepository = boletoRepository;
            _httpClient = httpClient;
        }

        public async Task<List<BoletoModel>> GetAll()
        {
            return await _boletoRepository.GetAll();
        }

        public async Task<List<BoletoModel>> GetAllByMatricula(int idMatricula)
        {
            return await _boletoRepository.GetAllByMatricula(idMatricula);
        }

        public async Task<BoletoModel> GetById(int idBoleto)
        {
            return await _boletoRepository.GetById(idBoleto);
        }

        public async Task<BoletoModel> Create(BoletoSwagger boleto)
        {
            //TODO
            // Chamada para o servico_matricula para validar o idmatricula e pegar o idusuario
            //MatriculaResponse matriculaInfo = await GetMatriculaInfoAsync(boleto.IdMatricula);

            //TODO
            // Chamada para o servico_usuario para pegar nome e cpf

            BoletoRequest boletoRequest = new BoletoRequest
            {
                Nome = $"João {DateTime.Now}" ,
                CPF = $"CPF: {DateTime.Now}",
                DataGeracao = DateTime.Now,
                MesReferencia = boleto.MesReferencia,
                Valor = boleto.Valor,
                DataVencimento = boleto.DataVencimento
            };

            // Chamada para a api_financeiro para retornar a url do boleto
            string response = await GetBoletoInfoAsync(boletoRequest);

            BoletoModel dadosBoleto = new BoletoModel
            {
                IdMatricula = boleto.IdMatricula,
                Valor = boleto.Valor,
                MesReferencia = boleto.MesReferencia,
                DataGeracao = boletoRequest.DataGeracao,
                DataVencimento = boleto.DataVencimento,
                Pago = false,
                UrlBoleto = response
            };

            return await _boletoRepository.Create(dadosBoleto);
        }

        public async Task<bool> Update(BoletoModel boleto, int idBoleto)
        {
            return await _boletoRepository.Update(boleto, idBoleto);
        }

        public async Task<bool> DeleteById(int idBoleto)
        {
            return await _boletoRepository.DeleteById(idBoleto);
        }

        private async Task<MatriculaResponse> GetMatriculaInfoAsync(int idMatricula)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://api.servico-matricula.com/matriculas/{idMatricula}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<MatriculaResponse>();
        }

        private async Task<string> GetBoletoInfoAsync(BoletoRequest boletoRequest)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("https://localhost:5001/api/Exemplo/gerar-boleto", boletoRequest);
            response.EnsureSuccessStatusCode();

            // Lê o conteúdo do corpo da resposta como uma string
            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }
    }
}
