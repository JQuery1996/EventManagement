using Domain.Model.EventModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations; 

public class EventConfigurations : IEntityTypeConfiguration<Event> {
    public void Configure(EntityTypeBuilder<Event> builder) {
        builder
            .ToTable("Events");

        builder
            .HasKey(e => e.Id);


        builder
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(e => e.NameEn)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .Property(e => e.NameAr)
            .IsRequired()
            .HasMaxLength(50);
        
        
        builder
            .Property(e => e.DescriptionEn)
            .IsRequired()
            .HasMaxLength(200);

        builder
            .Property(e => e.DescriptionAr)
            .IsRequired()
            .HasMaxLength(200);
        
        
        builder
            .Property(e => e.Location)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(e => e.AvailableTickets)
            .IsRequired();


        builder
            .Property(e => e.Date)
            .IsRequired();
        
        builder
            .Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");
        
        builder
            .Property(e => e.UpdateAt)
            .HasDefaultValueSql("GETUTCDATE()");
    }
}
