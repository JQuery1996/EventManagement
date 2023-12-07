namespace Contract.Responses.Events; 

public record EventResponse(
    int Id,
    string NameAr,
    string NameEn,
    string DescriptionEn,
    string DescriptionAr,
    string Location,
    int AvailableTickets,
    DateTime Date);
