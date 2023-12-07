using Application.Services.PermissionsManager.Common;
using ErrorOr;

namespace Application.Services.PermissionsManager.Interfaces; 

public interface IPermissionsManager {
   Task<IEnumerable<PermissionResult>> GetPermissionsAsync();
   Task<ErrorOr<IEnumerable<PermissionResult>>> GetPermissionsForRoleAsync(string roleName);
   Task<ErrorOr<Created>> AssignPermissionToRole(AssignPermissionToRoleCommand command);
}