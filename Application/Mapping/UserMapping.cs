using Application.Services.Users.Common;
using AutoMapper;
using Domain.Model.IdentityModels;

namespace Application.Mapping; 

public class UserMapping : Profile{
   public UserMapping() {
      CreateMap<User, UserResult>()
         .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
         .ForCtorParam("UserName", opt => opt.MapFrom(src => src.UserName))
         .ForCtorParam("Email", opt => opt.MapFrom(src => src.Email))
         .ForCtorParam("PhoneNumber", opt => opt.MapFrom(src => src.PhoneNumber));



      CreateMap<EditUserCommand, FilterUsersQuery>()
         .ForCtorParam("UserName", opt => opt.MapFrom(src => src.UserName))
         .ForCtorParam("Email", opt => opt.MapFrom(src => src.Email))
         .ForCtorParam("PhoneNumber", opt => opt.MapFrom(src => src.PhoneNumber));
   } 
    
}