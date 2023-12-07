using Application.Services.Bookings.Common;
using AutoMapper;
using Contract.Requests.Bookings;
using Contract.Responses.Bookings;

namespace Authorization.Mapping; 

public class BookingMapping : Profile{
    public BookingMapping() {
        CreateMap<BookForEventRequest, BookForEventCommand>()
            .ForCtorParam("EventId", opt => opt.MapFrom(src => src.EventId))
            .ForCtorParam("NumberOfTickets", opt => opt.MapFrom(src => src.NumberOfTickets));

        CreateMap<BookingResult, BookingResponse>()
            .ForCtorParam("Event", opt => opt.MapFrom(src => src.Event))
            .ForCtorParam("NumberOfTickets", opt => opt.MapFrom(src => src.NumberOfTickets))
            .ForCtorParam("Date", opt => opt.MapFrom(src => src.Date));
    }
    
}