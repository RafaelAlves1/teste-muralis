using AutoMapper;
using Desafio.Data;
using Desafio.DTO;
using Desafio.Exceptions;
using Desafio.Model;
using Desafio.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Services.Logicas
{
    public class ClienteBLL : IClienteBLL
    {
        private readonly DesafioContext _context;
        private readonly IMapper _mapper;
        private readonly ViaCepBLL _viaCepBLL;

        public ClienteBLL(DesafioContext context, IMapper mapper, ViaCepBLL viaCepBLL)
        {
            _context = context;
            _mapper = mapper;
            _viaCepBLL = viaCepBLL;
        }

        public async Task<RetornarClienteDTO> AdicionarCliente(AdicionarClienteDTO adicionarClienteDTO)
        {
            ValidarClienteParaAdicionar(adicionarClienteDTO);

            Cliente cliente = _mapper.Map<Cliente>(adicionarClienteDTO);

            cliente.Endereco = _viaCepBLL.RetornarInformacoesViaCep(cliente.Endereco.Cep);
            cliente.Endereco.Numero = adicionarClienteDTO.Endereco.Numero.Trim();
            cliente.Endereco.Complemento = adicionarClienteDTO.Endereco.Complemento.Trim();

            _context.Cliente.Add(cliente);

            await _context.SaveChangesAsync();

            RetornarClienteDTO retornarClienteCadastrado = _mapper.Map<RetornarClienteDTO>(cliente);


            return retornarClienteCadastrado;
        }

        private static void ValidarClienteParaAdicionar(AdicionarClienteDTO adicionarClienteDTO)
        {
            if (String.IsNullOrWhiteSpace(adicionarClienteDTO.Nome))
                throw new BadRequestException("É obrigatório informar um nome para cadastrar!");

            if (String.IsNullOrWhiteSpace(adicionarClienteDTO.Contato.Tipo))
                throw new BadRequestException("É obrigatório informar tipo de contato para cadastrar!");

            if (String.IsNullOrWhiteSpace(adicionarClienteDTO.Contato.Texto))
                throw new BadRequestException("É obrigatório informar texto no contato para cadastrar!");

            if (String.IsNullOrWhiteSpace(adicionarClienteDTO.Endereco.Cep))
                throw new BadRequestException("É obrigatório informar um cep para edição!");

            if (String.IsNullOrWhiteSpace(adicionarClienteDTO.Endereco.Numero))
                throw new BadRequestException("É obrigatório informar um número para edição!");
        }

        public async Task EditarCliente(int id, EditarClienteDTO editarClienteDTO)
        {
            if (id == 0)
                throw new BadRequestException("É obrigatório informar um id!");

            if (String.IsNullOrWhiteSpace(editarClienteDTO.Nome))
                throw new BadRequestException("É obrigatório informar um nome para edição!");

            Cliente? selecionarCliente = await _context.Cliente.Where(w => w.IdCliente == id).FirstOrDefaultAsync();

            if (selecionarCliente is null)
                throw new NotFoundException($"Não foi encontrado cliente com esse id na base de dados! Id utilizado: {id}");

            Cliente cliente = _mapper.Map<Cliente>(editarClienteDTO);

             selecionarCliente.Nome = cliente.Nome.Trim();

            _context.Cliente.Update(cliente);

            await _context.SaveChangesAsync();

        }
        
        public async Task EditarContatoCliente(int id, EditarContatoClienteDTO editarContatoClienteDTO)
        {
            if (id == 0)
                throw new BadRequestException("É obrigatório informar um id!");

            if (String.IsNullOrWhiteSpace(editarContatoClienteDTO.Tipo))
                throw new BadRequestException("É obrigatório informar um tipo de contato para edição!");

            if (String.IsNullOrWhiteSpace(editarContatoClienteDTO.Texto))
                throw new BadRequestException("É obrigatório informar um texto para edição!");

            Contato? selecionarContatoCliente = await _context.Contato.Where(w => w.IdCliente == id).FirstOrDefaultAsync();

            if (selecionarContatoCliente is null)
                throw new NotFoundException($"Não foi encontrado contato para esse cliente na base de dados! Id utilizado: {id}");

            Contato contato = _mapper.Map<Contato>(editarContatoClienteDTO);

            selecionarContatoCliente.Texto = contato.Texto.Trim();
            selecionarContatoCliente.Tipo = contato.Tipo.Trim();

            _context.Contato.Update(selecionarContatoCliente);

            await _context.SaveChangesAsync();

        }

        public async Task EditarEnderecoCliente(int id, EditarEnderecoClienteDTO editarEnderecoClienteDTO)
        {
            if (id == 0)
                throw new BadRequestException("É obrigatório informar um id!");

            if (String.IsNullOrWhiteSpace(editarEnderecoClienteDTO.Cep))
                throw new BadRequestException("É obrigatório informar um cep para edição!");

            if (String.IsNullOrWhiteSpace(editarEnderecoClienteDTO.Numero))
                throw new BadRequestException("É obrigatório informar um número para edição!");

            Endereco? selecionarEnderecoCliente = await _context.Endereco.Where(w => w.IdCliente == id).FirstOrDefaultAsync();

            if (selecionarEnderecoCliente is null)
                throw new NotFoundException($"Não foi encontrado endereço para esse cliente na base de dados! Id utilizado: {id}");

            Endereco endereco = _mapper.Map<Endereco>(editarEnderecoClienteDTO);

            var viaCep = _viaCepBLL.RetornarInformacoesViaCep(endereco.Cep);

            selecionarEnderecoCliente.Logradouro = viaCep.Logradouro.Trim();
            selecionarEnderecoCliente.Cep = viaCep.Cep.Trim();
            selecionarEnderecoCliente.Cidade = viaCep.Cidade.Trim();
            selecionarEnderecoCliente.Numero = endereco.Numero.Trim();
            selecionarEnderecoCliente.Complemento = endereco.Complemento.Trim();

            _context.Endereco.Update(selecionarEnderecoCliente);

            await _context.SaveChangesAsync();

        }

        public async Task DeletarCliente(int id)
        {
            if (id == 0)
                throw new BadRequestException("É obrigatório informar um id!");

            Cliente? selecionarCliente = await _context.Cliente.Where(w => w.IdCliente == id).FirstOrDefaultAsync();

            if (selecionarCliente is null)
                throw new NotFoundException($"Não foi encontrado cliente com esse id na base de dados! Id utilizado: {id}");

            _context.Cliente.Remove(selecionarCliente);

            await _context.SaveChangesAsync();
        }

        public async Task<List<RetornarClienteDTO>> RetornarTodosClientes()
        {
            List<Cliente> cliente = await _context.Cliente
                            .Include(c => c.Contato)
                            .Include(e => e.Endereco)
                            .ToListAsync();

            if(cliente.Count == 0)
                throw new NotFoundException("Nenhum cliente encontrado na base de dados!");

            List<RetornarClienteDTO> retorno = _mapper.Map<List<RetornarClienteDTO>>(cliente);

            return retorno;
        }

        public async Task<RetornarClienteDTO> RetornarClientePorId(int id)
        {
            if(id == 0)
                throw new BadRequestException("É obrigatório informar um id!");

            Cliente? cliente = await _context.Cliente
                            .Where(w => w.IdCliente == id).Include(c => c.Contato).Include(e => e.Endereco).FirstOrDefaultAsync();

            if (cliente is null)
                throw new NotFoundException($"Não foi encontrado cliente com esse id na base de dados! Id utilizado: {id}");

            RetornarClienteDTO retorno = _mapper.Map<RetornarClienteDTO>(cliente);

            return retorno;
        }
    }
}
