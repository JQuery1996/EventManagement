using Application.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Authentication; 

public class PermissionService(IUnitOfWork unitOfWork) : IPermissionService{
    public async Task<HashSet<string>> GetPermissionsAsync(string memberId) {
        var user = await unitOfWork.UserContainer.FindByIdAsync(memberId);
        if (user is null)
            return new HashSet<string>();
        var roles = await unitOfWork.UserContainer.GetRolesAsync(user);

        var result = new HashSet<string>();
        foreach (var role in roles) {
            var actualRole = await unitOfWork.Roles.FindAsync(
                r => EF.Functions.Like(r.Name, role),
                r => r.Permissions
                );
            foreach (var permission in actualRole!.Permissions)
                result.Add(permission.Name);
        }

        return result;
    }
}