using BombaPatch.Application.Dtos;

namespace BombaPatch.Application.Contratos
{
    public interface ISelecaoService
    {
         Task<SelecaoDto> AddSelecoes(SelecaoDto model);

         Task<SelecaoDto> UpdateSelecao(int selecaoId, SelecaoDto model);
         Task<bool> DeleteSelecao(int selecaoId); 

        //Seleção
        //Retorna Todas as seleções pelo nome
         Task<SelecaoDto[]> GetAllSelecoesByNomeAsync(string nome);
         //Retorna todas as seleções
         Task<SelecaoDto[]> GetAllSelecoesAsync();
         //Retorna a seleção pelo id
         Task<SelecaoDto> GetAllSelecaoByIdAsync(int selecaoId);
    }
}