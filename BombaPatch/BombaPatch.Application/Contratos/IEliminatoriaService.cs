using BombaPatch.Application.Dtos;

namespace BombaPatch.Application.Contratos
{
    public interface IEliminatoriaService
    {
        Task<EliminatoriaDto> AddEliminatoria(EliminatoriaDto model);
         Task<EliminatoriaDto> UpdateEliminatoria(int eliminatoriaId, EliminatoriaDto model);
         Task<bool> DeleteEliminatoria(int eliminatoriaId); 

        //Seleção
        //Retorna Todas as seleções pelo nome
         Task<List<EliminatoriaDto>> GetAllEliminatoriaByNomeAsync(string nome);
         //Retorna todas as seleções
         Task<List<EliminatoriaDto>> GetEliminatoriaAsync();
         //Retorna a seleção pelo id
         Task<EliminatoriaDto> GetAllEliminatoriaByIdAsync(int eliminatoriaId);
    }
}