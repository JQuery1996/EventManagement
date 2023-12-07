namespace Application.Services.Users.Common; 

public record EditUserCommand(string UserName, string Email, string PhoneNumber);