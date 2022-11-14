using BombaPatch.Domain;
using BombaPatch.Persistence.Contextos;
using BombaPatch.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace BombaPatch.Persistence
{
 public class SelecaoJogoResultadoPersist : ISelecaoJogoResultadoPersist 
    {
        private readonly BombaPatchContext _context;

        public SelecaoJogoResultadoPersist(BombaPatchContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<SelecaoJogoResultado[]> GetAllSelecaoJogoResultadoAsync()
        {
            IQueryable<SelecaoJogoResultado> query = _context.ResultadoSelecao;


            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<SelecaoJogoResultado[]> GetAllSelecaoJogoResultadoByNomeAsync(string nome)
        {
            IQueryable<SelecaoJogoResultado> query = _context.ResultadoSelecao;


            query = query.AsNoTracking().OrderBy(e => e.Id);
            //.Where(j => j.Selecao1.ToLower().Contains(nome.ToLower())) // dado um nome, converte em lowercase e ve se contem um metodo com esse nome
            //.Where(j => j.Selecao2.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<SelecaoJogoResultado> GetSelecaoJogoResultadoByIdAsync(int selecaoJogoResultadoId)
        {
            IQueryable<SelecaoJogoResultado> query = _context.ResultadoSelecao;


            query = query.AsNoTracking().OrderBy(e => e.Id)
            .Where(e => e.Id == selecaoJogoResultadoId); // dado um nome, converte em lowercase e ve se contem um metodo com esse nome

            return await query.FirstOrDefaultAsync();
        }
    }
}
