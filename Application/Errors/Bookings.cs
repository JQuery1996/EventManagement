using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace Application.Errors; 

public partial class ApplicationErrors{
    public class Bookings {
        public static Error NotFound = 
            Error.Validation("Booking.NotFound", "Booking does not exists");
        
        public static Error Insufficient = 
            Error.Validation("Booking.Insufficient",
            "Unable to complete the booking. Insufficient tickets available for the selected event.");

        public static Error Duplicate =
            Error.Conflict("Booking.Event", "There is a previous booking");
    }
    
}