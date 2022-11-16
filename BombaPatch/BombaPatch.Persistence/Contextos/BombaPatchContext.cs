using bombapatch.Domain;
using BombaPatch.Domain;
using Microsoft.EntityFrameworkCore;

namespace BombaPatch.Persistence.Contextos
{
    //contexto para herdar e criar a tabela do banco de dados
    public class BombaPatchContext : DbContext
    {
        //<>dentro dos operadores vai o contexto
        //onde vou passar a configuração feita na statup no base()
        public BombaPatchContext(DbContextOptions<BombaPatchContext> options) : base(options){ }

        //mapeamento da classe para fazer o banco de dados 
        public DbSet<Selecao> Selecoes { get; set; }
        public DbSet<Arbitro> Arbitros { get; set; }
        public DbSet<Estadio> Estadios { get; set; }
        public DbSet<Fase> Fases { get; set; }
        public DbSet<Grupo> GruposSelecoes { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Jogo> Jogos { get; set;}
        public DbSet<JogoResultado> ResultadoJogos { get; set; }
        public DbSet<SelecaoJogoResultado> ResultadoSelecao { get; set; }
        public DbSet<GrupoClassificacao> GrupoClassificacao { get; set; }
        public DbSet<Eliminatoria> Eliminatoria { get; set; }
        public DbSet<Partida> Partidas { get; set; }
        //public DbSet<Eliminatoria> Eliminatorias {get; set;}

        //apagar tabelas com mais de uma chave foreingn key
       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Selecao>()
                .HasMany(s => s.Jogadores)
                .WithOne(J => J.Selecao )
                .OnDelete(DeleteBehavior.Cascade);
        }*/
        
    }
    
}