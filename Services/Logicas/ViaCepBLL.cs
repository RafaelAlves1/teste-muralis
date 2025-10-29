using AutoMapper;
using Desafio.DTO;
using Desafio.Exceptions;
using Desafio.Model;
using Newtonsoft.Json;

namespace Desafio.Services.Logicas
{
    public class ViaCepBLL
    {
        private readonly string _baseUrl = "https://viacep.com.br/ws";
        private readonly IMapper _mapper;

        public ViaCepBLL(IMapper mapper)
        {
            _mapper = mapper;
        }


        public HttpResponseMessage ConsultarCep(string cep)
        {
            using HttpClient client = new();

            HttpRequestMessage requisicao = new()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_baseUrl}/{cep}/json")
            };

            HttpResponseMessage resposta = client.SendAsync(requisicao).Result;

            return resposta;
        }

        public Endereco RetornarInformacoesViaCep(string cep)
        {
            cep = cep.Replace("-", "").Trim(); ;

            var viaCep = ConsultarCep(cep);

            if (!viaCep.IsSuccessStatusCode)
                throw new BadRequestException("Cep não encontrado! Verifique a digitação");

            var resultado = viaCep.Content.ReadAsStringAsync().Result;

            var converterResultado = JsonConvert.DeserializeObject<ViaCepDTO>(resultado);

            Endereco endereco = _mapper.Map<Endereco>(converterResultado);
            endereco.Cidade = converterResultado!.Localidade;

            return endereco;
        }
    }
}
