using Application.Services;
using Application.Services.Authentication.Implementations;
using Application.Services.Authentication.Interfaces;
using Application.Services.Bookings.Implements;
using Application.Services.Bookings.Interfaces;
using Application.Services.Events.Implementations;
using Application.Services.Events.Interfaces;
using Application.Services.PermissionsManager.Implementations;
using Application.Services.PermissionsManager.Interfaces;
using Application.Services.RolesManager.Implementations;
using Application.Services.RolesManager.Interfaces;
using Application.Services.Users.Implementations;
using Application.Services.Users.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application; 

public static class DependencyInjection {
    public static IServiceCollection AddApplication(this IServiceCollection services) {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IPermissionsManager, PermissionsManager>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IBookingService, BookingService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ServiceContainer>();
        services.AddAutoMapper(typeof(DependencyInjection));
        return services;
    }
    
}