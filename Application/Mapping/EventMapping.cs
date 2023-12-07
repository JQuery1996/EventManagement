using Application.Services.Events.Common;
using AutoMapper;
using Domain.Model.EventModels;

namespace Application.Mapping; 

public class EventMapping : Profile{
    public EventMapping() {
        CreateMap<CreateEventCommand, Event>()
            .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.NameEn))
            .ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.NameAr))
            .ForMember(dest => dest.DescriptionEn, opt => opt.MapFrom(src => src.DescriptionEn))
            .ForMember(dest => dest.DescriptionAr, opt => opt.MapFrom(src => src.DescriptionAr))
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
            .ForMember(dest => dest.AvailableTickets, opt => opt.MapFrom(src => src.AvailableTickets))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date));
        
        
        CreateMap<Event, EventResult>()
            .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("NameEn", opt => opt.MapFrom(src => src.NameEn))
            .ForCtorParam("NameAr", opt => opt.MapFrom(src => src.NameAr))
            .ForCtorParam("DescriptionEn", opt => opt.MapFrom(src => src.DescriptionEn))
            .ForCtorParam("DescriptionAr", opt => opt.MapFrom(src => src.DescriptionAr))
            .ForCtorParam("Location", opt => opt.MapFrom(src => src.Location))
            .ForCtorParam("AvailableTickets", opt => opt.MapFrom(src => src.AvailableTickets))
            .ForCtorParam("Date", opt => opt.MapFrom(src => src.Date));
        
        
        
        CreateMap<EditEventCommand, Event>()
            .ForMember(dest => dest.NameEn, opt => opt.Condition(src => src.NameEn is not null ))
            .ForMember(dest => dest.NameAr, opt => opt.Condition(src => src.NameAr is not null ))
            .ForMember(dest => dest.DescriptionEn, opt => opt.Condition(src => src.DescriptionEn is not null))
            .ForMember(dest => dest.DescriptionAr, opt => opt.Condition(src => src.DescriptionAr is not null))
            .ForMember(dest => dest.Location, opt => opt.Condition(src => src.Location is not null))
            .ForMember(dest => dest.AvailableTickets, opt => opt.Condition(src => src.AvailableTickets is not null))
            .ForMember(dest => dest.Date, opt => opt.Condition(src => src.Date is not null));
            
    }
    
}