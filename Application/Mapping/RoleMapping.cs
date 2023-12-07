using Application.Services.RolesManager.Common;
using AutoMapper;
using Domain.Model.IdentityModels;

namespace Application.Mapping; 

public class RoleMapping : Profile{
   public RoleMapping() {
      CreateMap<Role, RoleResult>()
         .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
         .ForCtorParam("Name", opt => opt.MapFrom(src => src.Name))
         .ForCtorParam("NormalizedName", opt => opt.MapFrom(src => src.NormalizedName));
   } 
}