using Contract.Responses.Events;

namespace Contract.Responses.Bookings; 

public record BookingResponse(
    EventResponse Event,
    int NumberOfTickets,
    DateTime Date);