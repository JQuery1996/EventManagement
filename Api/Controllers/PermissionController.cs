using Application.Services;
using Application.Services.PermissionsManager.Common;
using AutoMapper;
using Contract.Requests.Permissions;
using Contract.Responses.Permissions;
using Domain.Constants;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.Controllers; 

[Route("/api/permission")]
public class PermissionController(
      ServiceContainer serviceContainer,
      IMapper mapper): ApiController {
   [HttpGet("Permissions")]
   [HasPermission(Permissions.ViewPermissions)]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status401Unauthorized)]
   [ProducesResponseType(StatusCodes.Status403Forbidden)]
   public async Task<IEnumerable<PermissionResponse>> ListAll() {
      return mapper.Map<IEnumerable<PermissionResponse>>(
         await serviceContainer.PermissionsManager.GetPermissionsAsync());
   }

   [HttpGet("RolePermissions")]
   [HasPermission(Permissions.AccessPermissions)]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status401Unauthorized)]
   [ProducesResponseType(StatusCodes.Status403Forbidden)]
   public async Task<IActionResult> ListPermissionForRole(string role) {
      var listPermissionForRoleResult 
         = await serviceContainer.PermissionsManager.GetPermissionsForRoleAsync(role);
      return listPermissionForRoleResult.Match(
         result => Ok(mapper.Map<IEnumerable<PermissionResponse>>(result))
         , Problem);
   }
   [HttpPost]
   [HasPermission(Permissions.CreatePermission)]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status401Unauthorized)]
   [ProducesResponseType(StatusCodes.Status403Forbidden)]
   public async Task<IActionResult> AddPermissionToRole(AssignPermissionToRoleRequest request) {
      var addPermissionToRoleResult 
         = await serviceContainer.PermissionsManager.AssignPermissionToRole(mapper.Map<AssignPermissionToRoleCommand>(request));
      return addPermissionToRoleResult.Match(result => NoContent(), Problem);
   }
}