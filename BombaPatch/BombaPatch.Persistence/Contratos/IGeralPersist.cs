using System.Threading.Tasks;
using bombapatch.Domain;
using BombaPatch.Domain;

namespace BombaPatch.Persistence
{
    public interface IGeralPersist
    {
        //Itens Gerais para adicionar, salvar, deletar e salvar
         void Add<T>(T entity) where T: class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         void DeleteRange<T>(T[] entity) where T: class;

         Task<bool> SaveChangesAsync();

    }
}