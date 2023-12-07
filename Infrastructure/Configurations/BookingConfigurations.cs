using Domain.Model.BookingModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations; 

public class BookingConfigurations : IEntityTypeConfiguration<Booking> {
    public void Configure(EntityTypeBuilder<Booking> builder) {
        builder
            .ToTable("Bookings");

        builder
            .HasKey(booking => new { booking.UserId, booking.EventId });
        
        builder
            .Property(booking => booking.NumberOfTickets)
            .IsRequired();

        builder
            .Property(booking => booking.Date)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");
        
        builder
            .Property(booking => booking.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");
        
        builder
            .Property(booking => booking.UpdateAt)
            .HasDefaultValueSql("GETUTCDATE()");


        builder
            .HasOne(booking => booking.User)
            .WithMany(user => user.Bookings)
            .HasForeignKey(booking => booking.UserId)
            .OnDelete(DeleteBehavior.Restrict);


        builder
            .HasOne(booking => booking.Event)
            .WithMany(e => e.Bookings)
            .HasForeignKey(booking => booking.EventId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}