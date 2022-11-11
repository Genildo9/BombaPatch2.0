using bombapatch.Domain;
using BombaPatch.Domain;
using BombaPatch.Persistence.Contextos;
using Microsoft.EntityFrameworkCore;

namespace BombaPatch.Persistence
{
    public class SelecaoPersist : ISelecaoPersist
    {
        private readonly BombaPatchContext _context;
        public SelecaoPersist(BombaPatchContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }

        public async Task<Selecao[]> GetAllSelecoesAsync()
        {
            IQueryable<Selecao> query = _context.Selecoes;

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Selecao[]> GetAllSelecoesByNomeAsync(string nome)
        {
            IQueryable<Selecao> query = _context.Selecoes;

            query = query.AsNoTracking().OrderBy(e => e.Id)
            .Where(s => s.Nome.ToLower().Contains(nome.ToLower())); // dado um nome, converte em lowercase e ve se contem um metodo com esse nome

            return await query.ToArrayAsync();
        }

        public async Task<Selecao> GetAllSelecaoByIdAsync(int SelecaoId)
        {
            IQueryable<Selecao> query = _context.Selecoes;

            query = query.AsNoTracking().OrderBy(e => e.Id)
            .Where(s => s.Id == SelecaoId); // dado um nome, converte em lowercase e ve se contem um metodo com esse nome

            return await query.FirstOrDefaultAsync();
        }

    }
}