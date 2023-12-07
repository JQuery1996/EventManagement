namespace Application.Services.Users.Common; 

public record FilterUsersQuery(string? UserName, string? Email, string? PhoneNumber);