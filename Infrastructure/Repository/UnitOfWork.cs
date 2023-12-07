using Application.Repository;
using Domain.Model.BookingModels;
using Domain.Model.EventModels;
using Domain.Model.IdentityModels;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repository;

public class UnitOfWork(
        ApplicationDbContext context, 
        UserManager<User> userManager, 
        RoleManager<Role> roleManager) : IUnitOfWork {
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