using WebStudio.Application_core.Interface;
using WebStudio.Application_core.Database_Context;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;


namespace WebStudio.Application_core.Services
    
{
    public abstract  class RepositoryBase<T>:IRepositoryBase<T> where T: class
    {
        protected RepositoryContext RepositoryContext;

        public RepositoryBase(RepositoryContext repositorycontext)
        {
            RepositoryContext = repositorycontext;
        }
        // The trackchange is used to improve our read-query performance. when it is set as false , I attached the AsnoTracking() method to the query to inform
        //EFcore that it does not need to track changes for the required entities because it does it by default.
        //The FindAll is an extension method same goes with FindByCondition.
        public  IQueryable<T> FindAll(bool trackChanges) => (!trackChanges ? RepositoryContext.Set<T>().AsNoTracking() : RepositoryContext.Set<T>());
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool trackChanges) =>(!trackChanges ? RepositoryContext.Set<T>().Where<T>(condition).AsNoTracking() : RepositoryContext.Set<T>().Where(condition));
        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }
    }
}
