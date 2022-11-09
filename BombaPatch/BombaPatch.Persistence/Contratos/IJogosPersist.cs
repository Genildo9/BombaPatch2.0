using bombapatch.Domain;
using BombaPatch.Domain;

namespace BombaPatch.Persistence
{
    public interface IJogosPersist
    {
        //Seleção
        //Retorna Todas as seleções pelo nome
         Task<Jogos[]> GetAllJogosByNomeAsync(string nome);
         //Retorna todas as seleções
         Task<Jogos[]> GetAllJogosAsync();
         //Retorna a seleção pelo id
         Task<Jogos> GetAllJogoByIdAsync(int jogosId);
    }
}