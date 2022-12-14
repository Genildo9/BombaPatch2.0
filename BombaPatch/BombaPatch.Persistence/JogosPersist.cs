using bombapatch.Domain;
using BombaPatch.Domain;
using BombaPatch.Persistence.Contextos;
using Microsoft.EntityFrameworkCore;

namespace BombaPatch.Persistence
{
    public class JogoPersist : IJogoPersist 
    {
        private readonly BombaPatchContext _context;

        public JogoPersist(BombaPatchContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Jogo[]> GetAllJogosAsync()
        {
            IQueryable<Jogo> query = _context.Jogos;


            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Jogo[]> GetAllJogosByNomeAsync(string nome)
        {
            IQueryable<Jogo> query = _context.Jogos;


            query = query.AsNoTracking().OrderBy(e => e.Id);
            //.Where(j => j.Selecao1.ToLower().Contains(nome.ToLower())) // dado um nome, converte em lowercase e ve se contem um metodo com esse nome
            //.Where(j => j.Selecao2.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Jogo> GetJogoByIdAsync(int JogosId)
        {
            IQueryable<Jogo> query = _context.Jogos;


            query = query.AsNoTracking().OrderBy(e => e.Id)
            .Where(e=> e.Id == JogosId); // dado um nome, converte em lowercase e ve se contem um metodo com esse nome

            return await query.FirstOrDefaultAsync();
        }
       
    }
}