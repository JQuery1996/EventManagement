namespace Contract.Requests.Users; 

public record FilterUsersRequest(string? UserName, string? Email, string? PhoneNumber);