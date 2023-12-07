using Application.Services.Events.Common;
using Application.Services.Users.Common;
using AutoMapper;
using Contract.Requests.Events;
using Contract.Requests.Users;
using Contract.Responses.Users;
using Domain.Model.IdentityModels;

namespace Authorization.Mapping; 

public class UserMapping : Profile{
    public UserMapping() {
        CreateMap<User, UserResponse>()
            .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("UserName", opt => opt.MapFrom(src => src.Email))
            .ForCtorParam("Email", opt => opt.MapFrom(src => src.UserName))
            .ForCtorParam("PhoneNumber", opt => opt.MapFrom(src => src.PhoneNumber));
        
        CreateMap<CreateEventRequest, CreateEventCommand>()
            .ForCtorParam("NameEn", opt => opt.MapFrom(src => src.NameEn))
            .ForCtorParam("NameAr", opt => opt.MapFrom(src => src.NameAr))
            .ForCtorParam("DescriptionEn", opt => opt.MapFrom(src => src.DescriptionEn))
            .ForCtorParam("DescriptionAr", opt => opt.MapFrom(src => src.DescriptionAr))
            .ForCtorParam("Location", opt => opt.MapFrom(src => src.Location))
            .ForCtorParam("Date", opt => opt.MapFrom(src => src.Date));


        CreateMap<FilterUsersRequest, FilterUsersQuery>()
            .ForCtorParam("UserName", opt => opt.MapFrom(src => src.UserName))
            .ForCtorParam("Email", opt => opt.MapFrom(src => src.Email))
            .ForCtorParam("PhoneNumber", opt => opt.MapFrom(src => src.PhoneNumber));
        
        CreateMap<EditUserRequest, EditUserCommand>()
            .ForCtorParam("UserName", opt => opt.MapFrom(src => src.UserName))
            .ForCtorParam("Email", opt => opt.MapFrom(src => src.Email))
            .ForCtorParam("PhoneNumber", opt => opt.MapFrom(src => src.PhoneNumber));
    }
}