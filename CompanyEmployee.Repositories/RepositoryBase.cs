using CompanyEmployee.Contracts;
using CompanyEmployee.Entities.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CompanyEmployee.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext RepositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? RepositoryContext.Set<T>().AsNoTracking() : RepositoryContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) => 
            !trackChanges ? RepositoryContext.Set<T>().Where(expression).AsNoTracking() 
            : RepositoryContext.Set<T>().Where(expression);
    }
}