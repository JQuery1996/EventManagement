using System.Net;
using System.Security.Claims;
using Application.Errors;
using Application.Interfaces;
using Application.Repository;
using Application.Services.Authentication.Common;
using Application.Services.Authentication.Interfaces;
using Domain.Constants;
using Domain.Model.IdentityModels;
using ErrorOr;

namespace Application.Services.Authentication.Implementations; 

public class AuthService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUnitOfWork unitOfWork
    ) : IAuthService{
    public async Task<ErrorOr<AuthenticationResult>> Login(LoginQuery query) {
        await Task.CompletedTask;
        if (await unitOfWork.UserContainer.FindByNameAsync(query.UserName) is not { } user)
            return ApplicationErrors.Authentication.InvalidAuthentication;
        if (await unitOfWork.UserContainer.CheckPasswordAsync(user, query.Password) is false)
            return ApplicationErrors.Authentication.InvalidAuthentication;
        return new AuthenticationResult(
            User: user,
            Token: await jwtTokenGenerator.GenerateToken(user)
        );
    }

    public async Task<ErrorOr<AuthenticationResult>> Register(RegisterCommand command) {
        if (await unitOfWork.UserContainer.FindByNameAsync(command.UserName) is { } user)
            return ApplicationErrors.Authentication.Duplicate;
        
        var createdUser = new User {
            UserName = command.UserName,
            Email = command.Email,
        };

        var result = await unitOfWork.UserContainer.CreateAsync(createdUser, command.Password);
        if (!result.Succeeded) {
            return Error.Custom((int)HttpStatusCode.UnprocessableContent, "Authentication.Failed", "Failed to create user.");
        }

        await unitOfWork.UserContainer.AddToRoleAsync(createdUser, nameof(Roles.User));
        return new AuthenticationResult(
            User: createdUser, 
            Token: await jwtTokenGenerator.GenerateToken(createdUser));
    }

    public async Task<User?> GetAuthenticatedUser(ClaimsPrincipal user) {
        return await unitOfWork.UserContainer.GetUserAsync(user);
    }
}