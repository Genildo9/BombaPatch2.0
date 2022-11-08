using bombapatch.Domain;
using BombaPatch.Domain;
using BombaPatch.Persistence.Contextos;
using Microsoft.EntityFrameworkCore;

namespace BombaPatch.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        private readonly BombaPatchContext _context;
        public GeralPersist(BombaPatchContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;  // se o retorno for maior que 0, ouve alteração
        }

    }
}
