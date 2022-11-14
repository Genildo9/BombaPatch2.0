using BombaPatch.Domain;
using BombaPatch.Persistence.Contextos;
using BombaPatch.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace BombaPatch.Persistence
{
 public class EliminatoriaPersist : IEliminatoriaPersist 
    {
        private readonly BombaPatchContext _context;

        public EliminatoriaPersist(BombaPatchContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Eliminatoria[]> GetAllEliminatoriaAsync()
        {
            IQueryable<Eliminatoria> query = _context.Eliminatoria;


            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Eliminatoria[]> GetAllEliminatoriaByNomeAsync(string nome)
        {
            IQueryable<Eliminatoria> query = _context.Eliminatoria;


            query = query.AsNoTracking().OrderBy(e => e.Id);
            //.Where(j => j.Selecao1.ToLower().Contains(nome.ToLower())) // dado um nome, converte em lowercase e ve se contem um metodo com esse nome
            //.Where(j => j.Selecao2.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Eliminatoria> GetEliminatoriaByIdAsync(int eliminatoriaId)
        {
            IQueryable<Eliminatoria> query = _context.Eliminatoria;


            query = query.AsNoTracking().OrderBy(e => e.Id)
            .Where(e => e.Id == eliminatoriaId); // dado um nome, converte em lowercase e ve se contem um metodo com esse nome

            return await query.FirstOrDefaultAsync();
        }
    }
}
