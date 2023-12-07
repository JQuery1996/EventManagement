using Application.Services.Bookings.Common;
using AutoMapper;
using Domain.Model.BookingModels;

namespace Application.Mapping; 

public class BookingMapping : Profile{
    public BookingMapping() {
        CreateMap<Booking, BookingResult>()
            .ForCtorParam("Event", opt => opt.MapFrom(src => src.Event))
            .ForCtorParam("NumberOfTickets", opt => opt.MapFrom(src => src.NumberOfTickets))
            .ForCtorParam("Date", opt => opt.MapFrom(src => src.Date));
    }
    
}