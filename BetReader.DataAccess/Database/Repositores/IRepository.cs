using System.Linq;

namespace BetReader.DataAccess.Database.Repositores
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void SaveChanges();
    }
}
