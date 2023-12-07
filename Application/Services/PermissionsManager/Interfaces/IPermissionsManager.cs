using Application.Services.PermissionsManager.Common;
using Domain.Model;
using ErrorOr;

namespace Application.Services.PermissionsManager.Interfaces; 

public interface IPermissionsManager {
   Task<IEnumerable<PermissionResult>> GetPermissionsAsync();
   Task<ErrorOr<IEnumerable<PermissionResult>>> GetPermissionsForRoleAsync(string roleName);
   Task<ErrorOr<Created>> AssignPermissionToRole(AssignPermissionToRoleCommand command);
}