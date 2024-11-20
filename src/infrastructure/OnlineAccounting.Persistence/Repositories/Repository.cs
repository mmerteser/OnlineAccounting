using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnlineAccounting.Application.Repositories;
using OnlineAccounting.Domain.Entities;

namespace OnlineAccounting.Persistence.Repositories;

public class Repository<TContext, TEntity>(TContext context) : IRepository<TContext, TEntity>
    where TEntity : Entity, new()
    where TContext : DbContext
{
    public DbSet<TEntity> Table => context.Set<TEntity>();

    public IQueryable<TEntity> Query(bool asNoTracking = false)
    {
        return asNoTracking ? Table.AsNoTracking() : Table.AsQueryable();
    }

    public async Task<TEntity?> GetById(long id, bool asNoTracking = false)
    {
        return await Query(asNoTracking).FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<List<TEntity>> GetAll(bool asNoTracking = false)
    {
        return await Query(asNoTracking).ToListAsync();
    }

    public async Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = false)
    {
        return await Query(asNoTracking).Where(predicate).ToListAsync();
    }

    public async Task<TEntity?> GetFirst(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = false)
    {
        return await Query(asNoTracking).FirstOrDefaultAsync(predicate);
    }

    public async ValueTask<EntityEntry<TEntity>> Add(TEntity entity)
    {
        return await Table.AddAsync(entity);
    }

    public async Task AddRange(IEnumerable<TEntity> entities)
    {
        await Table.AddRangeAsync(entities);
    }

    public void Remove(TEntity entity)
    {
        Table.Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        Table.RemoveRange(entities);
    }

    public void Update(TEntity entity)
    {
        Table.Update(entity);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        Table.UpdateRange(entities);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}