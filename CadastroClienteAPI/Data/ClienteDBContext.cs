using CadastroClienteAPI.Data.Map;
using CadastroClienteAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroClienteAPI.Data
{
    public class ClienteDBContext : DbContext
    {
        //CRIANDO UM CONSTRUTOR 
        public ClienteDBContext(DbContextOptions<ClienteDBContext> options) : base(options) 
        {


        }
        public DbSet<ClienteModel> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ADICIONANDO A CLASSE MAPEAMENTO NO CONTEXTO
            modelBuilder.ApplyConfiguration(new ClienteMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
