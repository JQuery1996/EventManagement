using Contract.Responses.Users;

namespace Contract.Responses.Authentications;

public record AuthenticationResponse(UserResponse User, string Token);