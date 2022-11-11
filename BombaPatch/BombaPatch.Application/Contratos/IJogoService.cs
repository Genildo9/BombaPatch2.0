using BombaPatch.Application.Dtos;

namespace BombaPatch.Application.Contratos
{
    public interface IJogoService
    {
         Task<JogoDto> AddJogos(JogoDto model);
         Task<JogoDto> UpdateJogo(int jogoId, JogoDto model);
         Task<bool> DeleteJogo(int jogoId); 

        //Seleção
        //Retorna Todas as seleções pelo nome
         Task<List<JogoDto>> GetAllJogosByNomeAsync(string nome);
         //Retorna todas as seleções
         Task<List<JogoDto>> GetAllJogosAsync();
         //Retorna a seleção pelo id
         Task<JogoDto> GetAllJogoByIdAsync(int jogoId);
    }
}