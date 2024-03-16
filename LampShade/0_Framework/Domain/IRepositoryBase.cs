
using System.Linq.Expressions;

namespace _0_Framework.Domain
{
    public interface IRepositoryBase<TKey,T> where T : class
    {
        T GetBy(TKey id);
        List<T> GetAll();
        void Create(T entity);
        void Save();
        bool Exists(Expression<Func<T,bool>> expression) ;

    }
}
