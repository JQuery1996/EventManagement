
namespace Domain.Model.IdentityModels; 

public class RolePermission {
    public string RoleId { get; set; } = null!;
    public int PermissionId { get; set; }
}