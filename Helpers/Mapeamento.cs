using AutoMapper;
using Desafio.DTO;
using Desafio.Model;

namespace Desafio.Helpers
{
    public class Mapeamento : Profile
    {
        public Mapeamento()
        {
            #region ADICIONAR 

            CreateMap<AdicionarClienteDTO, Cliente>();
            CreateMap<AdicionarEnderecoClienteDTO, Endereco>();
            CreateMap<AdicionarContatoClienteDTO, Contato>();

            #endregion


            #region RETORNAR

            CreateMap<Cliente, RetornarClienteDTO>();
            CreateMap<RetornarClienteDTO, Cliente>();

            CreateMap<Contato, RetornarContatoClienteDTO>();
            CreateMap<Endereco, RetornarEnderecoClienteDTO>();

            #endregion

            #region EDITAR 

            CreateMap<EditarClienteDTO, Cliente>();
            CreateMap<EditarContatoClienteDTO, Contato>();
            CreateMap<EditarEnderecoClienteDTO, Endereco>();

            #endregion

            #region VIA CEP

            CreateMap<ViaCepDTO, Endereco>();

            #endregion
        }
    }
}
