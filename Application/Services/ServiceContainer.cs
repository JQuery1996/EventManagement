using Application.Services.Authentication.Interfaces;
using Application.Services.Bookings.Interfaces;
using Application.Services.Events.Interfaces;
using Application.Services.PermissionsManager.Interfaces;
using Application.Services.RolesManager.Interfaces;
using Application.Services.Users.Interfaces;

namespace Application.Services;

public class ServiceContainer(
    IAuthService authenticatedService,
    IBookingService bookingService,
    IEventService eventService,
    IPermissionsManager permissionsManager,
    IRoleService roleService,
    IUserService userService
) {
    public IAuthService AuthenticatedService { get; } = authenticatedService;
    public IBookingService BookingService { get; } = bookingService;
    public IEventService EventService { get; } = eventService;
    public IPermissionsManager PermissionsManager { get; } = permissionsManager;
    public IRoleService RoleService { get; } = roleService;
    public IUserService UserService { get; } = userService;
}
        