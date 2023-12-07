using Domain.Model.BookingModels;
using Domain.Model.EventModels;
using Domain.Model.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace Application.Repository; 

public interface IUnitOfWork : IDisposable{
   public UserManager<User> UserContainer { get; }
   public RoleManager<Role> RoleContainer { get; }

   public IBaseRepository<User> Users { get;  }
   public IBaseRepository<Role> Roles { get;  }
   public IBaseRepository<Permission> Permissions { get; }
   public IBaseRepository<RolePermission> RolePermissions { get; }
   
   public IBaseRepository<Event> Events { get; }
   public IBaseRepository<Booking> Bookings { get; }
   int Commit();
   Task<int> CommitAsync(CancellationToken cancellationToken = default);
}