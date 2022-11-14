using BombaPatch.Domain;
using BombaPatch.Persistence.Contextos;
using BombaPatch.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace BombaPatch.Persistence
{
        public class GrupoClassificacaoPersist : IGrupoClassificacaoPersist 
    {
        private readonly BombaPatchContext _context;

        public GrupoClassificacaoPersist(BombaPatchContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<GrupoClassificacao[]> GetAllGruposClassificacaoAsync()
        {
            IQueryable<GrupoClassificacao> query = _context.GrupoClassificacao;


            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<GrupoClassificacao[]> GetAllGruposClassificacaoByNomeAsync(string nome)
        {
            IQueryable<GrupoClassificacao> query = _context.GrupoClassificacao;


            query = query.AsNoTracking().OrderBy(e => e.Id);
            //.Where(j => j.Selecao1.ToLower().Contains(nome.ToLower())) // dado um nome, converte em lowercase e ve se contem um metodo com esse nome
            //.Where(j => j.Selecao2.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<GrupoClassificacao> GetAllGrupoClassificacaoByIdAsync(int GrupoClassificacaoId)
        {
            IQueryable<GrupoClassificacao> query = _context.GrupoClassificacao;


            query = query.AsNoTracking().OrderBy(e => e.Id)
            .Where(e => e.Id == GrupoClassificacaoId); // dado um nome, converte em lowercase e ve se contem um metodo com esse nome

            return await query.FirstOrDefaultAsync();
        }
       
    }
    
}