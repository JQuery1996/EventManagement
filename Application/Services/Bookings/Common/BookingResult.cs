using Application.Services.Events.Common;
using Application.Services.Users.Common;

namespace Application.Services.Bookings.Common; 

public record BookingResult(
    EventResult Event, 
    int NumberOfTickets, 
    DateTime Date);