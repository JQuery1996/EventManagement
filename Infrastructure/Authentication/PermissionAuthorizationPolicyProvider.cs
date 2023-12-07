using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Infrastructure.Authentication; 

public class PermissionAuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider{
    public PermissionAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options) : base(options) {
    }

    public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName) {
        var policy = await base.GetPolicyAsync(policyName);
        // if policy exist just return it and complete our method
        if (policy is not null)
            return policy;
        
        // policy here does not exist just create it and return it 
        return new AuthorizationPolicyBuilder()
            .AddRequirements(new PermissionRequirement(policyName))
            .Build();

    }
}