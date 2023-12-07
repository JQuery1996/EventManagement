using Domain.Constants;
using Domain.Model.IdentityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations; 

public class RolePermissionConfigurations : IEntityTypeConfiguration<RolePermission> {
    public void Configure(EntityTypeBuilder<RolePermission> builder) {
        builder
            .ToTable(nameof(TableNames.RolePermissions));

        builder
            .HasKey(rp => new { rp.RoleId, rp.PermissionId });

    }
    
}