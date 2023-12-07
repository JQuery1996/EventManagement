using Domain.Constants;
using Domain.Model.IdentityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations; 

public sealed class RoleConfigurations : IEntityTypeConfiguration<Role>{
    public void Configure(EntityTypeBuilder<Role> builder) {
        builder
            .ToTable(nameof(TableNames.Roles));
        builder
            .HasKey(r => r.Id);
        
        builder
            .HasMany(role => role.Permissions)
            .WithMany(permission => permission.Roles)
            .UsingEntity<RolePermission>();

    }
}