using Domain.Model;

namespace Contract.Requests.Permissions; 

public record AssignPermissionToRoleRequest(string Permission, string Role);