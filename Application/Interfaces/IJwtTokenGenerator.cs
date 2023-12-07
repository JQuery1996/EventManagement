using Domain.Model.IdentityModels;

namespace Application.Interfaces; 

public interface IJwtTokenGenerator {
   Task<string> GenerateToken(User user);
}