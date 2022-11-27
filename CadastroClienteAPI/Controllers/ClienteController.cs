using CadastroClienteAPI.Models;
using CadastroClienteAPI.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClienteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        //CRIANDO O CONSTRUTOR
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        
        [HttpGet]
        public async Task <ActionResult<List<ClienteModel>>> BuscarTodosClientes()
        {
            List<ClienteModel> clientes = await _clienteRepositorio.BuscarTodosClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteModel>> BuscarPorId(int id)
        {
            ClienteModel clientes = await _clienteRepositorio.BuscarPorId(id);
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteModel>> Cadastrar([FromBody] ClienteModel clienteModel)
        {
            ClienteModel cliente = await _clienteRepositorio.Adicionar(clienteModel);
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar([FromBody] ClienteModel clienteModel, int id)
        { 
            clienteModel.Id = id;
            ClienteModel cliente = await _clienteRepositorio.Atualizar(clienteModel, id);
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteModel>> Apagar([FromBody] int id)
        {
            bool apagado = await _clienteRepositorio.Apagar(id);
            return Ok(apagado);
        
        
        }






    }
}
