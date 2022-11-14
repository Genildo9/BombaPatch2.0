using BombaPatch.Domain;

namespace BombaPatch.Persistence.Contratos
{
    public interface ISelecaoJogoResultadoPersist
    {
         //Retorna Todas as grupos pelo nome
         Task<SelecaoJogoResultado[]> GetAllSelecaoJogoResultadoByNomeAsync(string nome);
         //Retorna todas as grupos
         Task<SelecaoJogoResultado[]> GetAllSelecaoJogoResultadoAsync();
         //Retorna a grupo pelo id
         Task<SelecaoJogoResultado> GetSelecaoJogoResultadoByIdAsync(int selecaojogoresultadoId);
    }
}