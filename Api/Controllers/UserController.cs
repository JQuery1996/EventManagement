using Application.Services;
using Application.Services.Users.Common;
using AutoMapper;
using Contract.Requests.Users;
using Contract.Responses.Users;
using Domain.Constants;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Authorization.Controllers; 

[Route("/api/user")]
public class UserController(
   ServiceContainer serviceContainer,
   IMapper mapper
   ): ApiController{
   [HttpGet]
   [HasPermission(Permissions.ViewUsers)]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status401Unauthorized)]
   [ProducesResponseType(StatusCodes.Status403Forbidden)]
   public async Task<IActionResult> All() {
      return Ok(mapper.Map<IEnumerable<UserResponse>>(await serviceContainer.UserService.GetUsersAsync()));
   }


   [HttpGet("{id}")]
   [HasPermission(Permissions.ShowUser)]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status401Unauthorized)]
   [ProducesResponseType(StatusCodes.Status403Forbidden)]
   [ProducesResponseType(StatusCodes.Status204NoContent)]
   public async Task<IActionResult> Get([FromRoute] string id) {
      if (await serviceContainer.UserService.GetUserByIdAsync(id) is not { } user)
         return NoContent();
      return Ok(mapper.Map<UserResponse>(user));
   }


   [HttpPost("filter")]
   [HasPermission(Permissions.ViewUsers)]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status404NotFound)]
   [ProducesResponseType(StatusCodes.Status403Forbidden)]
   [ProducesResponseType(StatusCodes.Status204NoContent)]
   public async Task<IActionResult> Filter(FilterUsersRequest request) {
      var result 
         = await serviceContainer.UserService.FilterUsersAsync(mapper.Map<FilterUsersQuery>(request));
      if (result.IsNullOrEmpty())
         return NoContent();
      return Ok(mapper.Map<IEnumerable<UserResponse>>(result));
   }


   [HttpPut("{id}")]
   [HasPermission(Permissions.EditUser)]
   [ProducesResponseType(StatusCodes.Status204NoContent)]
   [ProducesResponseType(StatusCodes.Status401Unauthorized)]
   [ProducesResponseType(StatusCodes.Status403Forbidden)]
   public async Task<IActionResult> Edit([FromRoute] string id, [FromBody] EditUserRequest request) {
      var result
         = await serviceContainer.UserService.EditUserAsync(id, mapper.Map<EditUserCommand>(request));
      return result.Match(_ => NoContent(), Problem);
   }

   [HttpDelete("{id}")]
   [HasPermission(Permissions.RemoveUser)]
   [ProducesResponseType(StatusCodes.Status204NoContent)]
   [ProducesResponseType(StatusCodes.Status404NotFound)]
   [ProducesResponseType(StatusCodes.Status401Unauthorized)]
   [ProducesResponseType(StatusCodes.Status403Forbidden)]
   public async Task<IActionResult> Remove(string id) {
      var removeResult = await serviceContainer.UserService.RemoveUserAsync(id);
      return removeResult.Match(_ => NoContent(), Problem);
   }
   
}