using System.Linq.Expressions;
using Entities;
using Repo.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repo;
public abstract class RepoBase<T> : IRepoBase<T> where T : class
{
    protected ravenContext _ctx { get; set; }
    public RepoBase(ravenContext ctx)
    {
        _ctx = ctx;
    }
    public void Create(T entity) => _ctx.Set<T>().Add(entity);
    public void Update(T entity) => _ctx.Set<T>().Update(entity);
    public void Delete(T entity) => _ctx.Set<T>().Remove(entity);
    public IQueryable<T> FindAll() => _ctx.Set<T>().AsNoTracking();
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
        _ctx.Set<T>().Where(expression).AsNoTracking();
}