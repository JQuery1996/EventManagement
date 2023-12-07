using Application.Errors;
using Application.Repository;
using Application.Services.RolesManager.Common;
using Application.Services.RolesManager.Interfaces;
using AutoMapper;
using Domain.Model.IdentityModels;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.RolesManager.Implementations; 


public class RoleService(
    IUnitOfWork unitOfWork,
    IMapper mapper
    ): IRoleService {
    public async Task<IEnumerable<RoleResult>> GetRolesAsync() {
        return mapper.Map<IEnumerable<RoleResult>>(await unitOfWork.RoleContainer.Roles.ToListAsync());
    }

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

