using System.ComponentModel.DataAnnotations;

namespace Desafio.DTO
{
    public class AdicionarClienteDTO
    {
        public string Nome { get; set; } = String.Empty;

        public AdicionarContatoClienteDTO Contato { get; set; } = new AdicionarContatoClienteDTO();

        public AdicionarEnderecoClienteDTO Endereco { get; set; } = new AdicionarEnderecoClienteDTO();
    }

    public class RetornarClienteDTO
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; } = String.Empty;

        public string DataCadastro { get; set; } = String.Empty;

        public RetornarContatoClienteDTO Contato { get; set; } = new RetornarContatoClienteDTO();

        public RetornarEnderecoClienteDTO Endereco { get; set; } = new RetornarEnderecoClienteDTO();
    }

    public class EditarClienteDTO
    {
        public string Nome { get; set; } = String.Empty;
    }

}
