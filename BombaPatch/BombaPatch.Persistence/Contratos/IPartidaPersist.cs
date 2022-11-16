using BombaPatch.Domain;

namespace BombaPatch.Persistence.Contratos
{
    public interface IPartidaPersist
    {
         //Retorna Todas as partidas pelo nome
         Task<Partida[]> GetAllPartidasByNomeAsync(string nome);
         //Retorna todas as partidas
         Task<Partida[]> GetAllPartidasAsync();
         //Retorna a Jogo pelo id
         Task<Partida> GetPartidaByIdAsync(int partidaId);
    }
}