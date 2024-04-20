using Imobiliaria.Api.Models;
using Microsoft.EntityFrameworkCore;

//Aqui são armazenados arquivos relacionados à persistência de dados, como configurações de conexão com o banco de dados.
namespace Imobiliaria.Api.Data
{
    //Sua única responsabilidade é representar o contexto do banco de dados e fornecer acesso aos conjuntos de entidades.
    //Está aberta para extensão, permitindo adicionar novos conjuntos de entidades conforme necessário, sem modificar o comportamento existente.
    public class ImobiliariaContext : DbContext
    {
        public ImobiliariaContext(DbContextOptions<ImobiliariaContext> options)
            : base(options)
        {
        }

        public DbSet<Proprietario> Proprietarios { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<Corretor> Corretores { get; set; }
        public DbSet<Inquilino> Inquilinos { get; set; }
        public DbSet<ContratoAluguel> ContratoAlugueis { get; set; }
    }
}
