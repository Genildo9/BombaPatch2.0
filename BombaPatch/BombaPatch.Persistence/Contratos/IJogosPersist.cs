using bombapatch.Domain;
using BombaPatch.Domain;

namespace BombaPatch.Persistence
{
    public interface IJogoPersist
    {
        //Jogos
        //Retorna Todas as jogos pelo nome
         Task<Jogo[]> GetAllJogosByNomeAsync(string nome);
         //Retorna todas as jogos
         Task<Jogo[]> GetAllJogosAsync();
         //Retorna a Jogo pelo id
         Task<Jogo> GetJogoByIdAsync(int jogosId);
    }
}