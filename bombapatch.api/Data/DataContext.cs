using bombapatch.api.Models;
using Microsoft.EntityFrameworkCore;

namespace bombapatch.api.Data
{
    //contexto para herdar e criar a tabela do banco de dados
    public class DataContext : DbContext
    {
        //<>dentro dos operadores vai o contexto
        //onde vou passar a configuração feita na statup no base()
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }

        //mapeamento da classe para fazer o banco de dados 
        public DbSet<Selecao> Selecoes { get; set; }
    }
    
}