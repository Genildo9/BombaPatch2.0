using BombaPatch.Application.Dtos;

namespace BombaPatch.Application.Contratos
{
    public interface IJogosService
    {
         Task<JogosDto> AddJogos(JogosDto model);

         Task<JogosDto> UpdateJogo(int jogosId, JogosDto model);
         Task<bool> DeleteJogo(int jogoId); 

        //Seleção
        //Retorna Todas as seleções pelo nome
         Task<JogosDto[]> GetAllJogosByNomeAsync(string nome);
         //Retorna todas as seleções
         Task<JogosDto[]> GetAllJogosAsync();
         //Retorna a seleção pelo id
         Task<JogosDto> GetAllJogoByIdAsync(int jogoId);
    }
}