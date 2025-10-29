using System.ComponentModel.DataAnnotations;

namespace Desafio.Model
{
    public class Contato
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Tipo { get; set; } = String.Empty;

        [MaxLength(500)]
        public string Texto { get; set; } = String.Empty;

        public int IdCliente { get; set; }

        public Cliente Cliente { get; set; } = null!;
    }
}
