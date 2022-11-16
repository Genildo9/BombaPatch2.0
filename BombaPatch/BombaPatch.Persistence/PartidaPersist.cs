using BombaPatch.Domain;
using BombaPatch.Persistence.Contextos;
using BombaPatch.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace BombaPatch.Persistence
{
    public class PartidaPersist : IPartidaPersist
    {
        private readonly BombaPatchContext _context;

        public PartidaPersist(BombaPatchContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Partida[]> GetAllPartidasAsync()
        {
            IQueryable<Partida> query = _context.Partidas;


            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Partida[]> GetAllPartidasByNomeAsync(string nome)
        {
            IQueryable<Partida> query = _context.Partidas;


            query = query.AsNoTracking().OrderBy(e => e.Id);
            //.Where(j => j.Selecao1.ToLower().Contains(nome.ToLower())) // dado um nome, converte em lowercase e ve se contem um metodo com esse nome
            //.Where(j => j.Selecao2.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Partida> GetPartidaByIdAsync(int PartidasId)
        {
            IQueryable<Partida> query = _context.Partidas;


            query = query.AsNoTracking().OrderBy(e => e.Id)
            .Where(e=> e.Id == PartidasId); // dado um nome, converte em lowercase e ve se contem um metodo com esse nome

            return await query.FirstOrDefaultAsync();
        }
    }
}