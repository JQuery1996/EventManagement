namespace Domain.Constants; 

public enum Permissions {
    None,
    
    AccessUsers,
    ViewUsers ,
    ShowUser,
    CreateUser,
    EditUser,
    RemoveUser,
   
    AccessRoles,
    ViewRoles,
    ViewRole,
    EditRole,
    RemoveRole,
    AssignRole,
    
    AccessPermissions,
    ViewPermissions,
    ShowPermission,
    CreatePermission,
    EditPermission,
    RemovePermission,
    
    
    AccessEvents,
    ViewEvents,
    ShowEvent,
    CreateEvent,
    EditEvent,
    RemoveEvent,
    
    
    AccessBookings,
    ViewBookings,
    ShowBooking,
    CreateBooking,
    EditBooking,
    RemoveBooking,
  
    All
}