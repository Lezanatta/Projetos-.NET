using System.Linq.Expressions;

namespace ApiNova.Repository
{
    public interface IRepository<T> 
    {
        IQueryable<T> Get();  
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(Expression<Func<T,bool>> predicate);
    }
}
