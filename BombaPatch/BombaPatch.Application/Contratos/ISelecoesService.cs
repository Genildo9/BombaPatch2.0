using bombapatch.Domain;

namespace BombaPatch.Application.Contratos
{
    public interface ISelecaoService
    {
         Task<Selecao> AddSelecoes(Selecao model);

         Task<Selecao> UpdateSelecao(int selecaoId, Selecao model);
         Task<bool> DeleteSelecao(int selecaoId); 

        //Seleção
        //Retorna Todas as seleções pelo nome
         Task<Selecao[]> GetAllSelecoesByNomeAsync(string nome);
         //Retorna todas as seleções
         Task<Selecao[]> GetAllSelecoesAsync();
         //Retorna a seleção pelo id
         Task<Selecao> GetAllSelecaoByIdAsync(int selecaoId);
    }
}