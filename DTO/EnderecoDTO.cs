using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Desafio.DTO
{
    public class AdicionarEnderecoClienteDTO
    {

        public string Cep { get; set; } = String.Empty;

        public string Logradouro { get; set; } = String.Empty;

        public string Cidade { get; set; } = String.Empty;

        public string Numero { get; set; } = String.Empty;

        public string Complemento { get; set; } = String.Empty;
    }

    public class RetornarEnderecoClienteDTO
    {
        public string Cep { get; set; } = String.Empty;

        public string Logradouro { get; set; } = String.Empty;

        public string Cidade { get; set; } = String.Empty;

        public string Numero { get; set; } = String.Empty;

        public string Complemento { get; set; } = String.Empty;
    }

    public class EditarEnderecoClienteDTO
    {
        public string Cep { get; set; } = String.Empty;

        [JsonIgnore]
        public string Logradouro { get; set; } = String.Empty;

        [JsonIgnore]
        public string Cidade { get; set; } = String.Empty;

        public string Numero { get; set; } = String.Empty;

        public string Complemento { get; set; } = String.Empty;
    }
}
