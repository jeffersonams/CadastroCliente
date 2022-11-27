using CadastroClienteAPI.Data;
using CadastroClienteAPI.Models;
using CadastroClienteAPI.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Unicode;

namespace CadastroClienteAPI.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly ClienteDBContext _dbcontext; //CRIANDO A INJEÇÃO DE DEPENDENCIA 
        public ClienteRepositorio(ClienteDBContext clienteDBContext)
        { 
            _dbcontext = clienteDBContext;    
            
        }
        public async Task<ClienteModel> Adicionar(ClienteModel cliente)
        {   
            ClienteModel clienteModel = new ClienteModel();
            clienteModel.Data = DateTime.Now;

           await _dbcontext.Clientes.AddAsync(cliente);
            await _dbcontext.SaveChangesAsync();
            return cliente;
        }
        public async Task<ClienteModel> Atualizar(ClienteModel cliente, int id)
        {
            ClienteModel clientePorId = await BuscarPorId(id); //VAI NO BANCO DE DADOS FAZER A BUSCA DO ID QUE FOI PASSADO COMO PARAMETRO
           
            if(clientePorId == null)
            {
                throw new Exception($"Usuaro par o ID:{id} nao foi encontrado.");
            }

            clientePorId.Nome = cliente.Nome;
            clientePorId.Sobrenome = cliente.Sobrenome;
            clientePorId.Rua = cliente.Rua;
            cliente.Bairro = cliente.Bairro;
            cliente.Numero = cliente.Numero;

            _dbcontext.Clientes.Update(clientePorId);
            await _dbcontext.SaveChangesAsync();
            return clientePorId;
        }

        public async Task<ClienteModel> BuscarPorId(int id)
        {
            return await _dbcontext.Clientes.FirstOrDefaultAsync(x => x.Id == id);//VAI NO BANCO DE DADOS PEGAR O VALOR IGUAL QUE FOI PASSADO COMO PARAMETRO
        }

        public async Task<List<ClienteModel>> BuscarTodosClientes()
        {
            return await _dbcontext.Clientes.ToListAsync(); //TOLISTASYNC VAI RETORNAR TODOS OS CLIENTES DO BD
        }
        public async Task<bool> Apagar(int id)
        {
            ClienteModel clientePorId = await BuscarPorId(id); //VAI NO BANCO DE DADOS FAZER A BUSCA DO ID QUE FOI PASSADO COMO PARAMETRO

            if (clientePorId == null)
            {
                throw new Exception($"Usuaro par o ID:{id} nao foi encontrado.");
            }
           
           _dbcontext.Clientes.Remove(clientePorId);
           await _dbcontext.SaveChangesAsync();
           return true;


        }
    }
}
