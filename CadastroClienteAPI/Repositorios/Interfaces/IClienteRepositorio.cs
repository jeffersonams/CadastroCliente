using CadastroClienteAPI.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace CadastroClienteAPI.Repositorios.Interfaces
{
    public interface IClienteRepositorio
    {
        //VAI TER OS CONTRATOS DE CLIENTE
        Task<ClienteModel> Adicionar(ClienteModel cliente);
        Task<ClienteModel> Atualizar(ClienteModel cliente, int id);
        Task<List<ClienteModel>> BuscarTodosClientes();
        Task<ClienteModel> BuscarPorId(int id); //VAI RETORNAR UM USUARIO POR ID
        Task<bool> Apagar(int id);



        





    }
}
