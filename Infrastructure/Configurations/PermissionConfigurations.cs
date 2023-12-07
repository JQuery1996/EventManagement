using Domain.Constants;
using Domain.Model.IdentityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations; 

public sealed class PermissionConfigurations : IEntityTypeConfiguration<Permission>{
    public void Configure(EntityTypeBuilder<Permission> builder) {
        
        builder
            .ToTable(nameof(TableNames.Permissions));

        builder
            .HasKey(p => p.Id);

        builder
            .HasIndex(permission => permission.Name)
            .IsUnique();

    }
}