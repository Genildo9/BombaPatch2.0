using BombaPatch.Domain;

namespace BombaPatch.Persistence.Contratos
{
    public interface IGrupoClassificacaoPersist
    {
          //Retorna Todas as seleções pelo nome
         Task<GrupoClassificacao[]> GetAllGruposClassificacaoByNomeAsync(string nome);
         //Retorna todas as seleções
         Task<GrupoClassificacao[]> GetAllGruposClassificacaoAsync();
         //Retorna a seleção pelo id
         Task<GrupoClassificacao> GetAllGrupoClassificacaoByIdAsync(int GrupoClassificacaoId);
    }
}