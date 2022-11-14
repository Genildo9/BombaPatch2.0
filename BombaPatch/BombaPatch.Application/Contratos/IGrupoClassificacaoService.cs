using BombaPatch.Application.Dtos;
using BombaPatch.Domain;

namespace BombaPatch.Application.Contratos
{
    public interface IGrupoClassificacaoService
    {
        Task<GrupoClassificacao> AddGrupoClassificacao(GrupoClassificacaoDto model);
        Task<GrupoClassificacaoDto> UpdateGrupoClassificacao(int grupoClassificacaoId, GrupoClassificacaoDto model);
        Task<bool> DeleteGrupoClassificacao(int grupoClassificacaoId); 

        Task<List<GrupoClassificacaoDto>> GetAllGruposClassificacaoByNomeAsync(string nome);
        Task<List<GrupoClassificacao>> GetAllGrupoClassificacaoAsync();
        Task<GrupoClassificacaoDto> GetAllGrupoClassificacaoByIdAsync(int grupoClassificacaoId);
    } 
}