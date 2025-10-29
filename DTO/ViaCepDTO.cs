using System.Text.Json.Serialization;

namespace Desafio.DTO
{
    public class ViaCepDTO
    {
        [JsonPropertyName("cep")]
        public string Cep { get; set; } = String.Empty;

        [JsonPropertyName("logradouro")]
        public string Logradouro { get; set; } = String.Empty;

        [JsonPropertyName("localidade")]
        public string Localidade { get; set; } = String.Empty;


    }
}
