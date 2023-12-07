using Application.Services.RolesManager.Common;
using Domain.Model.IdentityModels;
using ErrorOr;

namespace Application.Services.RolesManager.Interfaces; 

public interface IRoleService {
    Task<IEnumerable<RoleResult>> GetRolesAsync();  
    Task<ErrorOr<Created>> AssignRoleToUserAsync(User user, string roleName);
}