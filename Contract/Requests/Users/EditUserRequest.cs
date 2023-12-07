namespace Contract.Requests.Users; 

public record EditUserRequest(string? UserName, string? Email, string? PhoneNumber);