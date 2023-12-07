namespace Application.Services.Events.Common; 

public record EventResult(
    int Id,
    string NameAr,
    string NameEn,
    string DescriptionAr,
    string DescriptionEn,
    string Location,
    int AvailableTickets,
    DateTime Date);