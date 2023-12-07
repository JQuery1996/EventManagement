namespace Contract.Requests.Roles; 

public record AssignRoleToUserRequest(int UserId, string Role);