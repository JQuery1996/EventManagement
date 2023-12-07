namespace Application.Services.Events.Common; 

public record EditEventCommand(
    string? NameEn,
    string? NameAr,
    string? DescriptionEn,
    string? DescriptionAr,
    string? Location,
    int? AvailableTickets,
    DateTime? Date);
