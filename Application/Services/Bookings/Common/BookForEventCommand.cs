namespace Application.Services.Bookings.Common; 

public record BookForEventCommand(int EventId, int NumberOfTickets);