using Microsoft.EntityFrameworkCore;

namespace OnlineAccounting.Application.Repositories;

public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
{
    Task<int> CompleteAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}