using BombaPatch.Application.Dtos;
using BombaPatch.Domain;

namespace BombaPatch.Application.Contratos
{
    public interface IGrupoService
    {
        Task<Grupo> AddGrupo(GrupoDto model);
        Task<GrupoDto> UpdateGrupo(int grupoId, GrupoDto model);
        Task<bool> DeleteGrupo(int grupoId); 

        Task<List<GrupoDto>> GetAllGruposByNomeAsync(string nome);
        Task<List<Grupo>> GetAllGrupoAsync();
        Task<GrupoDto> GetAllGrupoByIdAsync(int grupooId);
    }
}