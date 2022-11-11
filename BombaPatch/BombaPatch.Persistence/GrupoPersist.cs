using bombapatch.Domain;
using BombaPatch.Domain;
using BombaPatch.Persistence.Contextos;
using Microsoft.EntityFrameworkCore;

namespace BombaPatch.Persistence
{
    public class GrupoPersist : IGrupoPersist 
    {
        private readonly BombaPatchContext _context;

        public GrupoPersist(BombaPatchContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Grupo[]> GetAllGruposAsync()
        {
            IQueryable<Grupo> query = _context.GruposSelecoes;


            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Grupo[]> GetAllGruposByNomeAsync(string nome)
        {
            IQueryable<Grupo> query = _context.GruposSelecoes;


            query = query.AsNoTracking().OrderBy(e => e.Id);
            //.Where(j => j.Selecao1.ToLower().Contains(nome.ToLower())) // dado um nome, converte em lowercase e ve se contem um metodo com esse nome
            //.Where(j => j.Selecao2.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Grupo> GetGrupoByIdAsync(int GrupoId)
        {
            IQueryable<Grupo> query = _context.GruposSelecoes;


            query = query.AsNoTracking().OrderBy(e => e.Id)
            .Where(e => e.Id == GrupoId); // dado um nome, converte em lowercase e ve se contem um metodo com esse nome

            return await query.FirstOrDefaultAsync();
        }
       
    }
}