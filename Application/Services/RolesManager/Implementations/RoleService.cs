using Application.Errors;
using Application.Repository;
using Application.Services.RolesManager.Interfaces;
using Domain.Model.IdentityModels;
using ErrorOr;

namespace Application.Services.RolesManager.Implementations; 


public class RoleService(IUnitOfWork unitOfWork): IRoleService {
    public async Task<ErrorOr<Created>> AssignRoleToUserAsync(User user, string roleName) {
        var role = await unitOfWork.RoleContainer.FindByNameAsync(roleName);
        if (role is null)
            return ApplicationErrors.Roles.NotFound;
        if (await unitOfWork.UserContainer.IsInRoleAsync(user, roleName))
            return ApplicationErrors.Roles.AlreadyIn;
        await unitOfWork.UserContainer.AddToRoleAsync(user, roleName);
        return Result.Created;
    }
}

