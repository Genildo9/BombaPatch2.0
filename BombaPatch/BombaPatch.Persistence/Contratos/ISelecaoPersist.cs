using bombapatch.Domain;

namespace BombaPatch.Persistence
{
    public interface ISelecaoPersist
    {
        //Seleção
        //Retorna Todas as seleções pelo nome
         Task<Selecao[]> GetAllSelecoesByNomeAsync(string nome);
         //Retorna todas as seleções
         Task<Selecao[]> GetAllSelecoesAsync();
         //Retorna a seleção pelo id
         Task<Selecao> GetAllSelecaoByIdAsync(int selecaoId);
    }
}