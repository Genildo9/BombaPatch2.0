using BombaPatch.Application.Dtos;

namespace BombaPatch.Application.Contratos
{
    public interface IPartidaService
    {
         Task<PartidaDto> AddPartidas(PartidaDto model);
         Task<PartidaDto> UpdatePartida(int partidaId, PartidaDto model);
         Task<bool> DeletePartida(int partidaId); 

        //Partida
        //Retorna Todas as Partidas pelo nome
         Task<List<PartidaDto>> GetAllPartidasByNomeAsync(string nome);
         //Retorna todas as Partidas
         Task<List<PartidaDto>> GetAllPartidasAsync();
         //Retorna a partida pelo id
         Task<PartidaDto> GetAllPartidaByIdAsync(int partidaId);
    }
}