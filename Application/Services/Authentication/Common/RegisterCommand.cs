namespace Application.Services.Authentication.Common; 

public record RegisterCommand(string UserName, string Email, string Password);