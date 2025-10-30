using System.ComponentModel.DataAnnotations;

namespace Desafio.Model
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [MaxLength(150)]
        public string Nome { get; set; } = String.Empty;

        public DateTime DataCadastro { get; set; }

        public Endereco Endereco { get; set; } = new Endereco();

        public Contato Contato { get; set; } = new Contato();
    }
}
