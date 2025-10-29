using System.ComponentModel.DataAnnotations;

namespace Desafio.DTO
{
    public class AdicionarContatoClienteDTO
    {
        public string Tipo { get; set; } = String.Empty;

        public string Texto { get; set; } = String.Empty;
    }

    public class RetornarContatoClienteDTO
    {
        public string Tipo { get; set; } = String.Empty;

        public string Texto { get; set; } = String.Empty;
    }

    public class EditarContatoClienteDTO
    {
        public string Tipo { get; set; } = String.Empty;

        public string Texto { get; set; } = String.Empty;
    }

}