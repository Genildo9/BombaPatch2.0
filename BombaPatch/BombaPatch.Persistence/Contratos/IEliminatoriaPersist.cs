using bombapatch.Domain;
using BombaPatch.Domain;

namespace BombaPatch.Persistence
{
    public interface IEliminatoriaPersist
    {
        //Jogos
        //Retorna Todas as jogos pelo nome
         Task<Eliminatoria[]> GetAllEliminatoriaByNomeAsync(string nome);
         //Retorna todas as jogos
         Task<Eliminatoria[]> GetAllEliminatoriaAsync();
         //Retorna a Jogo pelo id
         Task<Eliminatoria> GetEliminatoriaByIdAsync(int eliminatoriaId);
    }
}