using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnlineAccounting.Domain.Entities;

namespace OnlineAccounting.Application.Repositories.CompanyRepositories;

public interface IRepository<TContext, TEntity>
    where TEntity : Entity, new()
    where TContext : DbContext
{
    DbSet<TEntity> Table { get; }
    IQueryable<TEntity> Query(bool asNoTracking = false);
    Task<TEntity?> GetById(long id, bool asNoTracking = false);
    Task<List<TEntity>> GetAll(bool asNoTracking = false);
    Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = false);
    Task<TEntity?> GetFirst(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = false);
    ValueTask<EntityEntry<TEntity>> Add(TEntity entity);
    Task AddRange(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);

    Task SaveChangesAsync();
}