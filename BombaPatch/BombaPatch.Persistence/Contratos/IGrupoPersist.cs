using bombapatch.Domain;
using BombaPatch.Domain;

namespace BombaPatch.Persistence
{
    public interface IGrupoPersist
    {
        //Seleção
        //Retorna Todas as seleções pelo nome
         Task<Grupo[]> GetAllGruposByNomeAsync(string nome);
         //Retorna todas as seleções
         Task<Grupo[]> GetAllGruposAsync();
         //Retorna a seleção pelo id
         Task<Grupo> GetGrupoByIdAsync(int jogoId);
    }
}