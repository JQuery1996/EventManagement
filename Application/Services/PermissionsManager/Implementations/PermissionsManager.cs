using Application.Errors;
using Application.Repository;
using Application.Services.PermissionsManager.Common;
using Application.Services.PermissionsManager.Interfaces;
using AutoMapper;
using Domain.Model;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.PermissionsManager.Implementations; 

public class PermissionsManager(IUnitOfWork unitOfWork, IMapper mapper) : IPermissionsManager{
    public async Task<IEnumerable<PermissionResult>> GetPermissionsAsync() {
        return mapper.Map<IEnumerable<PermissionResult>>(await unitOfWork.Permissions.ToListAsync());
    }

    public async Task<ErrorOr<IEnumerable<PermissionResult>>> GetPermissionsForRoleAsync(string roleName) {
        var role = await unitOfWork.Roles.FindAsync(
            role => EF.Functions.Like(role.Name, roleName),
            role => role.Permissions);

        return role is null 
            ? ApplicationErrors.Roles.NotFound 
            : ErrorOrFactory.From(mapper.Map<IEnumerable<PermissionResult>>(role.Permissions));
    }

    public async Task<ErrorOr<Created>> AssignPermissionToRole(AssignPermissionToRoleCommand command) {
        var role = await unitOfWork.Roles
            .FindAsync(
                role => EF.Functions.Like(role.Name, command.Role),
                role => role.Permissions);
        if (role is null)
            return ApplicationErrors.Roles.NotFound;
        var permission = await unitOfWork.Permissions.FindAsync(permission => EF.Functions.Like(permission.Name, command.Permission));
        if (permission is null)
            return ApplicationErrors.Permissions.NotFound;

        if (role.Permissions.FirstOrDefault(
                pr => string.Equals(pr.Name, permission.Name, StringComparison.OrdinalIgnoreCase)) is not null )
            return ApplicationErrors.Permissions.Duplicate;
        role.Permissions.Add(permission);
        await unitOfWork.CommitAsync();
        return Result.Created;

    }
}