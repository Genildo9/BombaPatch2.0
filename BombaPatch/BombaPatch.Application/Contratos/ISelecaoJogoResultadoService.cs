using BombaPatch.Application.Dtos;
using BombaPatch.Domain;

namespace BombaPatch.Application.Contratos
{
    public interface ISelecaoJogoResultadoService
    {
        Task<SelecaoJogoResultadoDto> AddSelecaoJogoResultado(SelecaoJogoResultadoDto model);
        Task<SelecaoJogoResultadoDto> UpdateSelecaoJogoResultado(int selecaoJogoResultadoId, SelecaoJogoResultadoDto model);
        Task<bool> DeleteSelecaoJogoResultado(int selecaoJogoResultadoId); 

        Task<List<SelecaoJogoResultadoDto>> GetAllSelecaoJogoResultadoByNomeAsync(string nome);
        Task<List<SelecaoJogoResultadoDto>> GetAllSelecaoJogoResultadoAsync();
        Task<SelecaoJogoResultadoDto> GetAllSelecaoJogoResultadoByIdAsync(int selecaoJogoResultadoId);
    }
}