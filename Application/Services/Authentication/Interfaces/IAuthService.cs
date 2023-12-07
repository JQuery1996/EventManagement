using System.Security.Claims;
using Application.Services.Authentication.Common;
using Domain.Model.IdentityModels;
using ErrorOr;

namespace Application.Services.Authentication.Interfaces; 

public interface IAuthService {
   Task<ErrorOr<AuthenticationResult>> Login(LoginQuery query);
   Task<ErrorOr<AuthenticationResult>> Register(RegisterCommand command);

   public Task<User?> GetAuthenticatedUser(ClaimsPrincipal user);
}