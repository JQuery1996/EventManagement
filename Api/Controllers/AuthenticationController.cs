using Application.Services;
using Application.Services.Authentication.Common;
using AutoMapper;
using Contract.Requests.Authentication;
using Contract.Responses.Authentications;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.Controllers; 

[Route("/api/auth")]
public class AuthenticationController(
    ServiceContainer serviceContainer, 
    IMapper mapper
    ) : ApiController{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request) {
        var loginResult = await serviceContainer.AuthenticatedService.Login(
            mapper.Map<LoginQuery>(request));
        return loginResult.Match(
            result => Ok(mapper.Map<AuthenticationResponse>(result)), 
            Problem);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request) {
        var registerResult = await serviceContainer.AuthenticatedService.Register(mapper.Map<RegisterCommand>(request));
        return registerResult.Match(
            result => Ok(mapper.Map<AuthenticationResponse>(result)),
            Problem
        );
    }
}