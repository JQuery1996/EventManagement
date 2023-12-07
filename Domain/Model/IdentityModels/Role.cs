using Microsoft.AspNetCore.Identity;

namespace Domain.Model.IdentityModels; 

public class Role : IdentityRole {
    public List<Permission> Permissions { get; set; } = new();
}