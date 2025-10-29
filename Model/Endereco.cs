using System.ComponentModel.DataAnnotations;

namespace Desafio.Model
{
    public class Endereco
    {
        public int Id { get; set; }

        [MaxLength(9)]
        public string Cep { get; set; } = String.Empty;

        [MaxLength(250)]
        public string Logradouro { get; set; } = String.Empty;

        [MaxLength(250)]
        public string Cidade { get; set; } = String.Empty;

        [MaxLength(10)]
        public string Numero { get; set; } = String.Empty;

        [MaxLength(250)]
        public string Complemento { get; set; } = String.Empty;

        public int IdCliente { get; set; }

        public Cliente Cliente { get; set; } = null!;
    }
}
