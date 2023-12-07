using Application.Repository;
using Domain.Model.BookingModels;
using Domain.Model.EventModels;
using Domain.Model.IdentityModels;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Repository;

public class UnitOfWork(
        ApplicationDbContext context, 
        UserManager<User> userManager, 
        RoleManager<Role> roleManager) : IUnitOfWork {
    private IDbContextTransaction? _transaction;
    public UserManager<User> UserContainer { get; } = userManager;
    public RoleManager<Role> RoleContainer { get; } = roleManager;

    public IBaseRepository<User> Users { get; } =
        new BaseRepository<User>(context);

    public IBaseRepository<Role> Roles { get; } =
        new BaseRepository<Role>(context);
    public IBaseRepository<Permission> Permissions { get; } = 
        new BaseRepository<Permission>(context);
    
    public IBaseRepository<RolePermission> RolePermissions { get; } = 
        new BaseRepository<RolePermission>(context);


    public IBaseRepository<Event> Events { get; } = 
        new BaseRepository<Event>(context);
    
    public IBaseRepository<Booking> Bookings { get; } = 
        new BaseRepository<Booking>(context);
    
    public int Commit() {
        return context.SaveChanges();
    }

    public Task<int> CommitAsync(CancellationToken cancellationToken = default) {
        return context.SaveChangesAsync(cancellationToken);
    }

    public async Task BeginTransactionAsync() {
        _transaction = await context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync() {
        if (_transaction is null)
            return;
        try {
            await context.SaveChangesAsync();
            await _transaction.CommitAsync();
        }
        catch {
            await _transaction.RollbackAsync();
            throw;
        } 
    }
    public async Task RollbackTransactionAsync() {
        if (_transaction is null)
            return;
        await _transaction.RollbackAsync();
    }

    public void Dispose() { 
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private bool _disposed;

    private void Dispose(bool disposing) {
        if (!_disposed && disposing) context.Dispose();
        _disposed = true;
    } 
}