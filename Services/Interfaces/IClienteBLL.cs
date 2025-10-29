using Desafio.DTO;

namespace Desafio.Services.Interfaces
{
    public interface IClienteBLL
    {
        Task<RetornarClienteDTO> AdicionarCliente(AdicionarClienteDTO adicionarClienteDTO);

        Task EditarCliente(int id, EditarClienteDTO editarClienteDTO);

        Task EditarContatoCliente(int id, EditarContatoClienteDTO editarContatoClienteDTO);

        Task EditarEnderecoCliente(int id, EditarEnderecoClienteDTO editarEnderecoClienteDTO);

        Task DeletarCliente(int id);

        Task<List<RetornarClienteDTO>> RetornarTodosClientes();

        Task<RetornarClienteDTO> RetornarClientePorId(int id);
    }
}
