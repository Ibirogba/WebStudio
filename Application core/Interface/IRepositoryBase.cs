using System.Linq.Expressions;

namespace WebStudio.Application_core.Interface
{
   //A Base Repository serving as a generic repository for other repository classes
   //The IQueryable FindAll will return true if there is a change and indirectly set T and save the instance of T
   //
   //
    
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);


            
    }
}
