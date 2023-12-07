using Application.Services.Events.Common;

namespace Application.Services.Bookings.Common; 

public record BookingResult(
    EventResult Event, 
    int NumberOfTickets, 
    DateTime Date);