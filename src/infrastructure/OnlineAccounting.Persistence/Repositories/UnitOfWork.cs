using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OnlineAccounting.Application.Repositories;

namespace OnlineAccounting.Persistence.Repositories;

public class UnitOfWork<TContext>(TContext context) : IUnitOfWork<TContext>
    where TContext : DbContext
{
    private IDbContextTransaction _currentTransaction;

    public async Task BeginTransactionAsync()
    {
        _currentTransaction = await context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        if (_currentTransaction != null)
        {
            await context.SaveChangesAsync();
            await _currentTransaction.CommitAsync();
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_currentTransaction != null) await _currentTransaction.RollbackAsync();
    }

    public async Task<int> CompleteAsync()
    {
        return await context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _currentTransaction?.Dispose();
        context.Dispose();
    }
}