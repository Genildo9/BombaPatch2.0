using bombapatch.Domain;
using BombaPatch.Domain;
using BombaPatch.Persistence.Contextos;
using Microsoft.EntityFrameworkCore;

namespace BombaPatch.Persistence
{
    public class JogosPersist : IJogosPersist 
    {
        private readonly BombaPatchContext _context;

        public JogosPersist(BombaPatchContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Jogos[]> GetAllJogosAsync()
        {
            IQueryable<Jogos> query = _context.Jogos
                .Include(j => j.Estadio)
                .Include(j => j.Arbitro);

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Jogos[]> GetAllJogosByNomeAsync(string nome)
        {
            IQueryable<Jogos> query = _context.Jogos
                .Include(j => j.Estadio)
                .Include(j => j.Arbitro);

            query = query.AsNoTracking().OrderBy(e => e.Id)
            .Where(j => j.Nome.ToLower().Contains(nome.ToLower())); // dado um nome, converte em lowercase e ve se contem um metodo com esse nome

            return await query.ToArrayAsync();
        }

        public async Task<Jogos> GetAllJogoByIdAsync(int JogosId)
        {
            IQueryable<Jogos> query = _context.Jogos
                .Include(j => j.Estadio)
                .Include(j => j.Arbitro);

            query = query.AsNoTracking().OrderBy(e => e.Id)
            .Where(j => j.Id == JogosId); // dado um nome, converte em lowercase e ve se contem um metodo com esse nome

            return await query.FirstOrDefaultAsync();
        }
       
    }
}