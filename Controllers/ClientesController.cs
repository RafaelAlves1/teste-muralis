using Desafio.Data;
using Desafio.DTO;
using Desafio.Exceptions;
using Desafio.Model;
using Desafio.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteBLL _clienteBLL;

        public ClientesController(IClienteBLL clienteBLL)
        {
            _clienteBLL = clienteBLL;
        }

        [HttpGet("/clientes")]
        public async Task<IActionResult> RetornarTodosClientes()
        {
            try
            {
                List<RetornarClienteDTO> retorno = await _clienteBLL.RetornarTodosClientes();

                return Ok(retorno);
            }
           catch  (NotFoundException notFound)
            {
                return NotFound(notFound.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("/clientes/{id}")]
        public async Task<IActionResult> RetornarClientePorId(int id)
        {
            try
            {
                RetornarClienteDTO retorno = await _clienteBLL.RetornarClientePorId(id);

                return Ok(retorno);
            }
            catch (BadRequestException badRequest)
            {
                return NotFound(badRequest.Message);
            }
            catch (NotFoundException notFound)
            {
                return NotFound(notFound.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("/clientes")]
        public async Task<IActionResult> AdicionarCliente([FromBody] AdicionarClienteDTO adicionarClienteDTO)
        {
            try
            {
               RetornarClienteDTO clienteCadastrado = await _clienteBLL.AdicionarCliente(adicionarClienteDTO);

                return CreatedAtAction("AdicionarCliente", new { Cliente = clienteCadastrado });
            }
            catch (BadRequestException badRequest)
            {
                return NotFound(badRequest.Message);
            }
            catch (NotFoundException notFound)
            {
                return NotFound(notFound.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPatch("/clientes/{id}")]
        public async Task<IActionResult> EditarCliente(int id, [FromBody] EditarClienteDTO editarClienteDTO)
        {
            try
            {
                await _clienteBLL.EditarCliente(id, editarClienteDTO);

                return NoContent();
            }
            catch (BadRequestException badRequest)
            {
                return NotFound(badRequest.Message);
            }
            catch (NotFoundException notFound)
            {
                return NotFound(notFound.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("/clientes/{id}")]
        public async Task<IActionResult> DeletarCliente(int id)
        {
            try
            {
                await _clienteBLL.DeletarCliente(id);

                return NoContent();
            }
            catch (BadRequestException badRequest)
            {
                return NotFound(badRequest.Message);
            }
            catch (NotFoundException notFound)
            {
                return NotFound(notFound.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("/clientes/{id}/contato")]
        public async Task<IActionResult> EditarContatoCliente(int id, [FromBody] EditarContatoClienteDTO editarContatoClienteDTO)
        {
            try
            {
                await _clienteBLL.EditarContatoCliente(id, editarContatoClienteDTO);

                return NoContent();
            }
            catch (BadRequestException badRequest)
            {
                return NotFound(badRequest.Message);
            }
            catch (NotFoundException notFound)
            {
                return NotFound(notFound.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("/clientes/{id}/endereco")]
        public async Task<IActionResult> EditarEnderecoCliente(int id, [FromBody] EditarEnderecoClienteDTO editarEnderecoClienteDTO)
        {
            try
            {
                await _clienteBLL.EditarEnderecoCliente(id, editarEnderecoClienteDTO);

                return NoContent();
            }
            catch (BadRequestException badRequest)
            {
                return NotFound(badRequest.Message);
            }
            catch (NotFoundException notFound)
            {
                return NotFound(notFound.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
