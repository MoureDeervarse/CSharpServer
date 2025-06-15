using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebServer.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(object id);
        Task Add(T entity);
        Task Remove(T entity);
        Task SaveChanges();
    }
}
