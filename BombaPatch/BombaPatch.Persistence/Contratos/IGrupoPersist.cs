using bombapatch.Domain;
using BombaPatch.Domain;

namespace BombaPatch.Persistence
{
    public interface IGrupoPersist
    {
        //Seleção
        //Retorna Todas as grupos pelo nome
         Task<Grupo[]> GetAllGruposByNomeAsync(string nome);
         //Retorna todas as grupos
         Task<Grupo[]> GetAllGruposAsync();
         //Retorna a grupo pelo id
         Task<Grupo> GetGrupoByIdAsync(int jogoId);
    }
}