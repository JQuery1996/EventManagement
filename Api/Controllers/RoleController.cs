using Application.Services;
using Domain.Constants;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.Controllers; 

[Route("/api/role")]
public class RoleController(ServiceContainer serviceContainer) : ApiController{
    [HttpPost("assign")]
    [HasPermission(Permissions.AssignRole)]
   [ProducesResponseType(StatusCodes.Status204NoContent)]
   [ProducesResponseType(StatusCodes.Status401Unauthorized)]
   [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> AssignRoleToUser(string role) {
        var user = await serviceContainer.AuthenticatedService.GetAuthenticatedUser(this.User);
        if (user is null)
            return Unauthorized();
        var result = await serviceContainer.RoleService.AssignRoleToUserAsync(user, role);
        return result.Match(_ => NoContent(), Problem);
    }
}