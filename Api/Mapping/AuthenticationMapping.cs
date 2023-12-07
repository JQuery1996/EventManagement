using Application.Services.Authentication.Common;
using AutoMapper;
using Contract.Requests.Authentication;
using Contract.Responses.Authentications;

namespace Authorization.Mapping; 

public class AuthenticationMapping : Profile{
    public AuthenticationMapping() {
        CreateMap<LoginRequest, LoginQuery>()
            .ForCtorParam("UserName", opt => opt.MapFrom(src => src.UserName))
            .ForCtorParam("Password", opt => opt.MapFrom(src => src.Password));
        
        CreateMap<RegisterRequest, RegisterCommand>()
            .ForCtorParam("UserName", opt => opt.MapFrom(src => src.UserName))
            .ForCtorParam("Email", opt => opt.MapFrom(src => src.Email))
            .ForCtorParam("Password", opt => opt.MapFrom(src => src.Password));

        CreateMap<AuthenticationResult, AuthenticationResponse>()
            .ForCtorParam("User", opt => opt.MapFrom(src => src.User))
            .ForCtorParam("Token", opt => opt.MapFrom(src => src.Token));
    }
    
}