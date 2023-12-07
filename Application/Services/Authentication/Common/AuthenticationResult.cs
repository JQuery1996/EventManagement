using Domain.Model.IdentityModels;

namespace Application.Services.Authentication.Common; 

public record AuthenticationResult(User User, string Token);