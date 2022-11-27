using CadastroClienteAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroClienteAPI.Data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<ClienteModel>

    {
        public void Configure(EntityTypeBuilder<ClienteModel> builder)
        { //MAPEAMENTO - COLOCANDO REGRA NOS ATRIBUTOS
           builder.HasKey(x => x.Id);
           builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
           builder.Property(x => x.Sobrenome).IsRequired().HasMaxLength(100);
           builder.Property(x => x.Rua).HasMaxLength(100);
           builder.Property(x => x.Bairro).HasMaxLength(100);
           builder.Property(x => x.Numero).HasMaxLength(100);
            


        }
    }
}
