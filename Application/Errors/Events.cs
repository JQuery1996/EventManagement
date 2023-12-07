using ErrorOr;

namespace Application.Errors; 

public partial class ApplicationErrors {
    public class Events {
        public static Error NotFound =
            Error.NotFound("event.notFound", "Event Not Found");

        public static Error UnAuthorized =
            Error.Unauthorized("event.unauthorized", "your don't have permission to edit/remove event");

        public static Error HasBookings =
            Error.Conflict("event.hasBookings", "There are bookings for this event");
    }
    
}