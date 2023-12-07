using Application.Services.Events.Common;
using AutoMapper;
using Contract.Requests.Events;
using Contract.Responses.Events;

namespace Authorization.Mapping; 

public class EventMapping : Profile{
   public EventMapping() {
        CreateMap<EventResult, EventResponse>()
            .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("NameEn", opt => opt.MapFrom(src => src.NameEn))
            .ForCtorParam("NameAr", opt => opt.MapFrom(src => src.NameAr))
            .ForCtorParam("DescriptionEn", opt => opt.MapFrom(src => src.DescriptionEn))
            .ForCtorParam("DescriptionAr", opt => opt.MapFrom(src => src.DescriptionAr))
            .ForCtorParam("Location", opt => opt.MapFrom(src => src.Location))
            .ForCtorParam("AvailableTickets", opt => opt.MapFrom(src => src.AvailableTickets))
            .ForCtorParam("Date", opt => opt.MapFrom(src => src.Date));
        
        
        
        CreateMap<CreateEventRequest, CreateEventCommand>()
            .ForCtorParam("NameEn", opt => opt.MapFrom(src => src.NameEn))
            .ForCtorParam("NameAr", opt => opt.MapFrom(src => src.NameAr))
            .ForCtorParam("DescriptionEn", opt => opt.MapFrom(src => src.DescriptionEn))
            .ForCtorParam("DescriptionAr", opt => opt.MapFrom(src => src.DescriptionAr))
            .ForCtorParam("Location", opt => opt.MapFrom(src => src.Location))
            .ForCtorParam("AvailableTickets", opt => opt.MapFrom(src => src.AvailableTickets))
            .ForCtorParam("Date", opt => opt.MapFrom(src => src.Date));
        
        
        CreateMap<EditEventRequest, EditEventCommand>()
            .ForCtorParam("NameEn", opt => opt.MapFrom(src => src.NameEn))
            .ForCtorParam("NameAr", opt => opt.MapFrom(src => src.NameAr))
            .ForCtorParam("DescriptionEn", opt => opt.MapFrom(src => src.DescriptionEn))
            .ForCtorParam("DescriptionAr", opt => opt.MapFrom(src => src.DescriptionAr))
            .ForCtorParam("Location", opt => opt.MapFrom(src => src.Location))
            .ForCtorParam("AvailableTickets", opt => opt.MapFrom(src => src.AvailableTickets))
            .ForCtorParam("Date", opt => opt.MapFrom(src => src.Date));
   } 
}