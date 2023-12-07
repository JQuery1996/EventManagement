using Domain.Model.IdentityModels;
using ErrorOr;

namespace Application.Services.RolesManager.Interfaces; 

public interface IRoleService {
    Task<ErrorOr<Created>> AssignRoleToUserAsync(User user, string roleName);
}