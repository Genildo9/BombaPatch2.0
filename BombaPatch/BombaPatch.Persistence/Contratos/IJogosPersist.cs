using bombapatch.Domain;
using BombaPatch.Domain;

namespace BombaPatch.Persistence
{
    public interface IJogoPersist
    {
        //Seleção
        //Retorna Todas as seleções pelo nome
         Task<Jogo[]> GetAllJogosByNomeAsync(string nome);
         //Retorna todas as seleções
         Task<Jogo[]> GetAllJogosAsync();
         //Retorna a seleção pelo id
         Task<Jogo> GetJogoByIdAsync(int jogosId);
    }
}