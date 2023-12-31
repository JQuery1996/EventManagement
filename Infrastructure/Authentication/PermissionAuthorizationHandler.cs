﻿using System.Security.Claims;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Authentication;

public class PermissionAuthorizationHandler
    (IServiceScopeFactory serviceScopeFactory) : AuthorizationHandler<PermissionRequirement> {
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement) {
        await Task.CompletedTask;
        var memberId = context.User.Claims.FirstOrDefault(
            claim => claim.Type == ClaimTypes.Name)?.Value;
        if (string.IsNullOrEmpty(memberId))
            return;
        using var scope = serviceScopeFactory.CreateScope();
        var permissionService = scope.ServiceProvider
            .GetRequiredService<IPermissionService>();
        var permissions =
            await permissionService.GetPermissionsAsync(memberId);

        if (!string.IsNullOrEmpty(permissions.FirstOrDefault(permission =>
                permission == nameof(Permissions.All) || permission == requirement.Permission))  )
                context.Succeed(requirement);
            
    }
}