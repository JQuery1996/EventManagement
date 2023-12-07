namespace Application.Services.Events.Common; 

public record CreateEventCommand(
    string NameEn,
    string NameAr,
    string DescriptionEn,
    string DescriptionAr,
    string Location,
    int AvailableTickets,
    DateTime Date);