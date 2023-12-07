using Application.Services.PermissionsManager.Common;
using AutoMapper;
using Domain.Model.IdentityModels;

namespace Application.Mapping; 

public class PermissionMapping : Profile{
   public PermissionMapping() {
      CreateMap<Permission, PermissionResult>()
         .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
         .ForCtorParam("Name", opt => opt.MapFrom(src => src.Name));
   } 
}