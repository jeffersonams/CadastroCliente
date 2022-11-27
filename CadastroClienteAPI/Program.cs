using CadastroClienteAPI.Data;
using CadastroClienteAPI.Repositorios;
using CadastroClienteAPI.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CadastroClienteAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddEntityFrameworkSqlServer()// ADICIONANDO
            .AddDbContext<ClienteDBContext>(
             options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                
            );
            //CONFIGURANDO A INJEÇÃO DE DEPENDENCIA DO REPOSITORIO - TODA VEZ QUE CHAMAR A INTERFACE VAI SABER QUE A CLASSE VAI RESOLVER INSTANCIAR É O CLIENTEREPOSITORIO
            builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}