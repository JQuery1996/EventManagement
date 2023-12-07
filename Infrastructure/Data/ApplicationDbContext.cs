using Domain.Model.BookingModels;
using Domain.Model.EventModels;
using Domain.Model.IdentityModels;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data; 

public class ApplicationDbContext(
        DbContextOptions options
    ) : AuthenticationDbContext<User, Role> (options){
    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);
        builder
            .ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public required DbSet<Event> Events { get; init; }
    public required DbSet<Booking> Bookings { get; init; }
}