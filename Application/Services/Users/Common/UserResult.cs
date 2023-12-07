namespace Application.Services.Users.Common; 

public record UserResult(
    string Id,
    string UserName,
    string Email,
    string PhoneNumber);